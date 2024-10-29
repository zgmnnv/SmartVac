using System.ComponentModel.DataAnnotations;

namespace SmartVac.Api.Dto.Manipulation;

public class GetManipulationDto
{
    [Key]
    public long Id { get; set; }
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public long VaccineId { get; set; }
    public string Description { get; set; }
}