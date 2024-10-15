using System.ComponentModel.DataAnnotations;

namespace SmartVac.Api.Models;
public class Vaccine {
    [Key]
    public long Id { get; set;}
    [Required]
    public string Name { get; set;}
    public string Description { get; set;}
    [Required]
    public int MinAgeInMonth { get; set;}
}