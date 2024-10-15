using System.ComponentModel.DataAnnotations;

namespace SmartVac.Api.Db;

public class User
{
    [Key]
    public long Id { get; set; } 

    [Required]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }
    public long[] ChildrenIds { get; set; }
}