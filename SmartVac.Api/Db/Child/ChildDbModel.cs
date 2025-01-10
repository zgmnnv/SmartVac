using System.ComponentModel.DataAnnotations;
using SmartVac.Api.Dto.Child;

namespace SmartVac.Api.Db.Child;

public class ChildDbModel
{
    [Key]
    public long Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public DateTime BirthDate { get; set; }
    [Required]
    public long ParentId { get; set; }
    public long NextVacId { get; set; }
    public DateTime NextVacDate { get; set; }
    public long LastManipulationId { get; set; }
    
    public List<long> VaccineIds { get; set; }
}