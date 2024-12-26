using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SmartVac.Api.Dto.User;

public class LoginUserDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    [PasswordPropertyText]
    public string Password { get; set; }
}