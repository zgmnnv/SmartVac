using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SmartVac.Api.Db.Manipulation;
using SmartVac.Api.Dto.Manipulation;

namespace SmartVac.Api.Controllers;

public class ManipulationController : BaseController
{
    private readonly IManipulationRepository _repository;

    public ManipulationController(IManipulationRepository repository)
    {
        _repository = repository;
    }
    
    [AllowAnonymous]
    [HttpPost("AddManipulation")]
    public async Task<IActionResult> AddManipulationAsync([FromBody] CreateManipulationDto manipulation)
    {
        if (manipulation == null)
        {
            return BadRequest("Не переданы данные для записи в БД");
        }

        var newManipulation = new ManipulationDbModel
        {
            Date = manipulation.Date,
            ChildId = manipulation.ChildId,
            VaccineId = manipulation.VaccineId,
            Description = manipulation.Description
        };

        var id = await _repository.CreateManipulation(newManipulation);

        return Ok($"Создана запись о вакцинации. Id: {id}");
    }
    
    [AllowAnonymous]
    [HttpPut("UpdateManipulation")]
    public async Task<IActionResult> UpdateChildAsync([FromBody] ManipulationDbModel manipulation)
    {
        var manipulationDbData = await _repository.GetManipulationAsync(manipulation.Id);

        if (manipulationDbData == null)
        {
            return NotFound($"Запись о вакцинации с Id: {manipulation.Id} не найдена");
        }

        await _repository.UpdateManipulationAsync(manipulation);
        return Ok($"Данные о вакцинации с Id: {manipulation.Id} успешно обновлены");
    }
    
    [AllowAnonymous]
    [HttpGet("GetLastManipulationByChildId/{childId}")]
    public async Task<IActionResult> GetLastManipulationByChildId(int childId)
    {
        if (childId is 0 or < 0)
        {
            return BadRequest("Указано невалидное значение ID");
        }

        var manipulationList = await _repository.GetManipulationListByChildIdAsync(childId);
        var lastManipulation = manipulationList.LastOrDefault();
        
        return Ok(new
        {
            id = lastManipulation.Id,
            description = lastManipulation.Description,
            vaccineDate = lastManipulation.Date.ToString("yyyy-MM-dd")
        });
    }

    [AllowAnonymous]
    [HttpGet("GetAllManipulationByChildId/{childId}")]
    public async Task<IActionResult> GetAllManipulationByChildId(int childId)
    {
        if (childId is 0 or < 0)
        {
            return BadRequest("Указано невалидное значение ID");
        }

        return Ok(await _repository.GetManipulationListByChildIdAsync(childId));
    }
    
    [AllowAnonymous]
    [HttpGet("GetManipulation/{id}")]
    public async Task<IActionResult> GetUserAsync(long id)
    {
        var manipulation = await _repository.GetManipulationAsync(id);

        if (manipulation == null || id == 0)
        {
            return NotFound();
        }
        return Ok(manipulation);
    }

    [AllowAnonymous]
    [HttpDelete("DeleteManipulation/{id}")]
    public async Task<IActionResult> DeleteManipulationAsync(long id)
    {
        if (id == null || id == 0)
        {
            return BadRequest("Не переданы данные для удаления записи");
        }

        await _repository.DeleteManipulationAsync(id);
        return Ok($"Запись о вакцинации с Id: {id} удалена");
    }
}