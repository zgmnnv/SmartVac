using Microsoft.AspNetCore.Mvc;
using Npgsql;
using SmartVac.Api.Db;
using SmartVac.Api.Db.Child;
using SmartVac.Api.Dto.Child;
using System.Data;
using System.Threading.Tasks;

namespace SmartVac.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChildController : ControllerBase
    {
        private readonly IChildRepository _childRepository;

        public ChildController(IChildRepository childRepository)
        {
            _childRepository = childRepository;
        }


        [HttpPost("CreateChild")]
        public async Task<IActionResult> CreateChildAsync([FromBody] CreateChildDto child)
        {
            if (child == null)
            {
                return BadRequest("Не переданы параметры ребенка для записи в БД");
            }

            var newChild = new Child
            {
                Name = child.Name,
                BirthDate = child.BirthDate,
                Gender = child.Gender,
                ParentId = child.ParentId,
                NextVacId = child.NextVacId,
                NextVacDate = child.NextVacDate,
                LastManipulationId = child.LastManipulationId
            };

            var id = await _childRepository.CreateChildAsync(newChild);

            return Ok($"Создана запись о ребенке {child.Name}. Id: {id}");
        }

        [HttpPut("UpdateChild")]
        public async Task<IActionResult> UpdateChildAsync([FromBody] Child updatedChild)
        {
            var user = await _childRepository.GetChildAsync(updatedChild.Id);

            if (user == null)
            {
                return NotFound($"Ребенок с Id: {updatedChild.Id} не найден");
            }

            await _childRepository.UpdateChildAsync(updatedChild);
            return Ok("Данные успешно обновлены");
        }

        [HttpDelete("DeleteChild/{id}")]
        public async Task<IActionResult> DeleteChildAsync(long id)
        {
            if (id == 0)
            {
                return BadRequest("Значение Id не может быть равно 0");
            }

            var child = await _childRepository.GetChildAsync(id);

            if (child == null)
            {
                return NotFound($"Ребенок с Id: {id} не найден");
            }

            await _childRepository.DeleteChildAsync(id);
            return Ok($"Ребенок с Id {id} удален");
        }

        [HttpGet("GetChild/{id}")]
        public async Task<IActionResult> GetUserAsync(long id)
        {
            var child = await _childRepository.GetChildAsync(id);

            if (child == null)
            {
                return NotFound();
            }
            return Ok(child);
        }

        [HttpGet("GetChildrenByUser/{id}")]
        public async Task<IActionResult> GetChildrenByUserIdAsync(long id)
        {
            if (id == 0)
            {
                return BadRequest("Значение Id не может быть равно 0");
            }
            var childList = await _childRepository.GetChildListByParentIdAsync(id);
            return Ok(childList);
        }

    }
}
