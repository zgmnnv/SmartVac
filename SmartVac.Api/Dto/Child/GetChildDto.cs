using System.ComponentModel.DataAnnotations;

namespace SmartVac.Api.Dto.Child;

public class GetChildDto
{
    [Key]
    public long Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    DateTime BirthDate { get; set; }
    [Required]
    Gender Gender { get; set; }
    [Required]
    public long ParentId { get; set; }
    public long NextVacId { get; set; }
    public DateTime NextVacDate { get; set; }
    public long LastManipulationId { get; set; }
}