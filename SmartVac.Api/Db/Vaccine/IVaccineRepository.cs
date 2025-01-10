namespace SmartVac.Api.Db.Vaccine;

public interface IVaccineRepository
{
    Task<VaccineDbModel> GetVaccineByIdAsync(long vaccineId);
    Task<List<long>> GetVaccinesByChildIdAsync(long childId);
    Task<long> CreateVaccineAsync(VaccineDbModel vaccineDbModel);
    Task UpdateVaccineAsync(VaccineDbModel vaccineDbModel);
    Task DeleteVaccineAsync(long vaccineId);
    Task<IEnumerable<VaccineDbModel>> GetAllVaccinesAsync();
}