using System.ComponentModel.DataAnnotations;

namespace SmartVac.Api.Dto.Child;

public class CreateChildDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    DateTime BirthDate { get; set; }
    [Required]
    Gender Gender { get; set; }
}