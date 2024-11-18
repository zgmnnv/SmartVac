using System.ComponentModel.DataAnnotations;

namespace SmartVac.Api.Db.Manipulation;

public class ManipulationDbModel
{
    [Key]
    public long Id { get; set; }
    
    [Required]
    public DateTime Date { get; set; }
    
    [Required]
    public long ChildId { get; set; }
    
    [Required]
    public long VaccineId { get; set; }
    
    public string Description { get; set; }
}