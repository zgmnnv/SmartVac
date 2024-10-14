namespace SmartVac.Api.Models;

public class Child {
    public int Id { get; set;}
    public string Name { get; set;}
    DateTime BirthDate { get; set;}
    Gender Gender{ get; set;}
    public long ParentId { get; set;}
    public long NextVacId { get; set;}
    public DateTime NextVacDate { get; set; }
    public long LastManipulationId { get; set;}
}


    // id = models.AutoField(primary_key=True)
    // name = models.CharField(max_length=50)
    // birth_date = models.DateTimeField()
    // gender = models.CharField(max_length=50, default='Boy')
    // country = models.CharField(max_length=50, default='Russia')
    // parent_id = models.ForeignKey(User, on_delete=models.CASCADE)
    // next_vaccine_id = models.CharField(max_length=50, null=True)
    // last_vaccination_id = models.ForeignKey(Vaccinations, on_delete=models.CASCADE, null=True)
    // next_vaccine_date = models.DateTimeField(null=True)
    // last_vaccine_date = models.DateTimeField(null=True)