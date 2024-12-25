using Microsoft.AspNetCore.Mvc;
using SmartVac.Api.Db;
using SmartVac.Api.Dto.User;
using System.Threading.Tasks;
using SmartVac.Api.Db.User;

namespace SmartVac.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserDto user)
        {
            if (user == null)
            {
                return BadRequest("Не переданы параметры пользователя");
            }

            var newUser = new UserDbModel
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                ChildrenIds = Array.Empty<long>()
            };

            var id = await _userRepository.CreateUserAsync(newUser);

            return Ok($"Создан пользователь {user.Name}. Email: {user.Email}. Id: {id}");
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UserDbModel updatedUserDbModel)
        {
            var user = await _userRepository.GetUserAsync(updatedUserDbModel.Id);

            if (user == null)
            {
                return NotFound($"Пользователь с Id: {updatedUserDbModel.Id} не найден");
            }

            await _userRepository.UpdateUserAsync(updatedUserDbModel);
            return Ok($"Пользователь: {updatedUserDbModel.Id} обновлен");
        }

        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUserAsync(long id)
        {
            if (id is 0 or < 1)
            {
                return BadRequest("Значение Id не может быть равно или менье 0");
            }

            var user = await _userRepository.GetUserAsync(id);

            if (user == null)
            {
                return NotFound($"Пользователь с Id: {id} не найден");
            }

            await _userRepository.DeleteUserAsync(id);
            return Ok($"Пользователь с Id {id} удален");
        }

        [HttpGet("GetUser/{id}")]
        public async Task<IActionResult> GetUserAsync(long id)
        {
            var user = await _userRepository.GetUserAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
