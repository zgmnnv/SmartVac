using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using SmartVac.Api.Db.Manipulation;
using SmartVac.Api.Db.Vaccine;
using SmartVac.Api.Dto.Vaccine;
using SmartVac.Api.Service;

namespace SmartVac.Api.Controllers;

public class VaccineController(IVaccineRepository vaccineRepository, IVaccinationService vaccinationService, IManipulationRepository manipulationRepository) : BaseController
{
    private readonly IVaccineRepository _vaccineRepository = vaccineRepository;
    private readonly IVaccinationService _vaccinationService = vaccinationService;
    private readonly IManipulationRepository _manipulationRepository = manipulationRepository;


    [HttpPost("CreateVaccine")]
    public async Task<IActionResult> CreateVaccineAsync([FromBody] CreateVaccineDto vaccine)
    {
        if (vaccine is null)
        {
            return BadRequest("Не переданы параметры вакцины для записи в БД");
        }

        var newVaccine = new VaccineDbModel()
        {
            Name = vaccine.Name,
            Description = vaccine.Description,
            MinAgeInMonth = vaccine.MinAgeInMonth
        };

        var vaccineId = await _vaccineRepository.CreateVaccineAsync(newVaccine);
        return Ok($"Создана запись о вакцине {vaccine.Name}. Id: {vaccineId}");
    }

    [HttpGet("GetVaccine/{id}")]
    public async Task<IActionResult> GetVaccineAsync(long id)
    {
        if (id is 0 or < 0)
        {
            return BadRequest("Указано невалидное значение ID");
        }

        var vaccine = await _vaccineRepository.GetVaccineByIdAsync(id);
        return Ok(vaccine);
    }
    
    [HttpPost("CalculateNextVaccinationDate")]
    public async Task<IActionResult> CalculateNextVaccinationDateAsync([FromBody] NextVaccinationRequest request)
    {
        if (request.BirthDate == default(DateTime) || request.LastVaccinationDate == default(DateTime))
        {
            return BadRequest("Некорректный запрос. Проверьте дату рождения и дату последней вакцинации.");
        }

        var vaccines = await _vaccineRepository.GetAllVaccinesAsync();
        var manipulations = await _manipulationRepository.GetManipulationListByChildIdAsync(request.ChildId);

        try
        {
            var nextVaccinationDate = _vaccinationService.CalculateNextVaccinationDate(request.BirthDate, request.LastVaccinationDate, request.LastVaccineId, vaccines, manipulations);
            var nextVaccine = vaccines.FirstOrDefault(v => v.MinAgeInMonth == nextVaccinationDate.Month);

            if (nextVaccine != null)
            {
                return Ok(new
                {
                    Vaccine = nextVaccine.Name,
                    Description = nextVaccine.Description,
                    NextVaccinationDate = nextVaccinationDate.ToString("yyyy-MM-dd")
                });
            }
            else
            {
                return NotFound("Нет подходящей вакцины для указанного возраста.");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("GetAllChildVaccines/{id}")]
    public async Task<IActionResult> GetAllChildVaccinesAsync(long id)
    {
        if (id is 0 or < 0)
        {
            return BadRequest("Указано невалидное значение ID");
        }

        var vaccineList = await _vaccineRepository.GetVaccinesByChildIdAsync(id);
        return Ok(vaccineList);
    }

    [HttpGet("GetAllVaccines")]
    public async Task<IActionResult> GetAllVaccinesAsync()
    {
        var vaccineList = await _vaccineRepository.GetAllVaccinesAsync();
        return Ok(vaccineList);
    }

    [HttpPut("UpdateVaccine")]
    public async Task<IActionResult> UpdateVaccineAsync(VaccineDbModel updatedVaccine)
    {
        var vaccine = await _vaccineRepository.GetVaccineByIdAsync(updatedVaccine.Id);
        
        if (vaccine is null)
        {
            return NotFound($"Пользователь с Id: {updatedVaccine.Id} не найден");
        }

        await _vaccineRepository.UpdateVaccineAsync(updatedVaccine);
        return Ok($"Запись о вкацине: {updatedVaccine.Id} обновлена");
    }

    [HttpDelete("DeleteVaccine/{id}")]
    public async Task<IActionResult> DeleteVaccineAsync(long id)
    {
        var vaccine = await _vaccineRepository.GetVaccineByIdAsync(id);
        
        if (vaccine is null)
        {
            return NotFound($"Пользователь с Id: {id} не найден");
        }

        await _vaccineRepository.DeleteVaccineAsync(id);
        return Ok($"Пользователь с Id {id} удален");
    }
}