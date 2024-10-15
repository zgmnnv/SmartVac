using System.ComponentModel.DataAnnotations;

namespace SmartVac.Api.Dto.User;

public class GetUserDto
{
    [Key]
    public long Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }
    public List<long> ChildrenIds { get; set; }
}