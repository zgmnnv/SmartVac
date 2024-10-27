using System.ComponentModel.DataAnnotations;

namespace SmartVac.Api.Dto.Vaccine;
public class CreateVaccineDto
{
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    [Required]
    public int MinAgeInMonth { get; set; }
}