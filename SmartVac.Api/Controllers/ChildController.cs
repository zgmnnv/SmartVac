using Microsoft.AspNetCore.Mvc;
using SmartVac.Api.Db.Child;
using SmartVac.Api.Dto.Child;

namespace SmartVac.Api.Controllers
{
    public class ChildController : BaseController
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

            var newChild = new ChildDbModel
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
        public async Task<IActionResult> UpdateChildAsync([FromBody] ChildDbModel updatedChildDbModel)
        {
            var user = await _childRepository.GetChildAsync(updatedChildDbModel.Id);

            if (user == null)
            {
                return NotFound($"Ребенок с Id: {updatedChildDbModel.Id} не найден");
            }

            await _childRepository.UpdateChildAsync(updatedChildDbModel);
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
