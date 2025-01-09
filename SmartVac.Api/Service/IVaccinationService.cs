using SmartVac.Api.Db.Manipulation;
using SmartVac.Api.Db.Vaccine;

namespace SmartVac.Api.Service;

public interface IVaccinationService
{
    DateTime CalculateNextVaccinationDate(DateTime birthDate, DateTime lastVaccinationDate, long? lastVaccineId,
        IEnumerable<VaccineDbModel> vaccines, List<ManipulationDbModel> manipulations);
}