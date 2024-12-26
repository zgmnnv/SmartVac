using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using SmartVac.Api.Db;
using SmartVac.Api.Dto.User;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using SmartVac.Api.Db.User;

namespace SmartVac.Api.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserRepository _userRepository;
        private string _secretKey = "5c7fda8f5259c1bf42bfde5d0d6a897d0812c9b5495bac23b1916a6f72d56804";
        
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        [AllowAnonymous]
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
        
        [Authorize]
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

        [Authorize]
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

        [Authorize]
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

        [AllowAnonymous]
        [HttpPost("LoginUser")]
        public async Task<IActionResult> LoginUserAsync([FromBody] LoginUserDto loginUser)
        {
            if (loginUser == null || string.IsNullOrEmpty(loginUser.Email) || string.IsNullOrEmpty(loginUser.Password))
            {
                return BadRequest("Неверные данные для входа.");
            }

            var user = await _userRepository.GetUserByEmailAsync(loginUser.Email);

            if (user == null)
            {
                return Unauthorized("Неправильный email или пароль.");
            }
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                }),
                Expires = DateTime.UtcNow.AddDays(365), 
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey)),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(securityToken);

            return Ok(new { Token = jwtToken });
        }
    }
}
