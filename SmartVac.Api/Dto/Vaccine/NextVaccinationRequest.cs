namespace SmartVac.Api.Dto.Vaccine;

public class NextVaccinationRequest
{
    public DateTime BirthDate { get; set; }
    public DateTime LastVaccinationDate { get; set; }
    public long? LastVaccineId { get; set; }
    public long ChildId { get; set; }
}