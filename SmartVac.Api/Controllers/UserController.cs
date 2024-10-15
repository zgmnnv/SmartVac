using Microsoft.AspNetCore.Mvc;
using SmartVac.Api.Db;
using SmartVac.Api.Models;
using SmartVac.Api.Models.User;
using System.Threading.Tasks;

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

            var newUser = new Db.User
            {
                Name = user.Name,
                Email = user.Email,
                ChildrenIds = Array.Empty<long>()
            };

            var id = await _userRepository.CreateUserAsync(newUser);

            return Ok($"Создан пользователь {user.Name}. Email: {user.Email}. Id: {id}");
        }

        [HttpPut("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUserAsync([FromBody] User updatedUser)
        {
            var user = await _userRepository.GetUserAsync(updatedUser.Id);

            if (user == null)
            {
                return NotFound($"Пользователь с Id: {updatedUser.Id} не найден");
            }

            await _userRepository.UpdateUserAsync(updatedUser);
            return NoContent();
        }

        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUserAsync(long id)
        {
            if (id == 0)
            {
                return BadRequest("Значение Id не может быть равно 0");
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
