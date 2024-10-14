// class Vaccine(models.Model):
//     id = models.AutoField(primary_key=True)
//     name = models.CharField(max_length=50, unique=False)
//     description = models.TextField(max_length=300, unique=False)
//     min_age_in_month = models.IntegerField(unique=False)

namespace SmartVac.Api.Models;
public class Vaccine {
    public int Id { get; set;}
    public string Name { get; set;}
    public string Description { get; set;}
    public int MinAgeInMonth { get; set;}
}