using System.ComponentModel.DataAnnotations;

namespace SmartVac.Api.Dto.Child;

public class CreateChildDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public DateTime BirthDate { get; set; }
    [Required]
    public Gender Gender { get; set; }
    [Required]
    public long ParentId { get; set; }
    public long NextVacId { get; set; }
    public DateTime NextVacDate { get; set; }
    public long LastManipulationId { get; set; }
}