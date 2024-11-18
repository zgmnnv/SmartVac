using System.ComponentModel.DataAnnotations;

namespace SmartVac.Api.Dto.Manipulation;

public class CreateManipulationDto
{
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public long VaccineId { get; set; }
    [Required]
    public long ChildId { get; set; }
    public string Description { get; set; }
}