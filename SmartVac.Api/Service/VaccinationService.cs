using SmartVac.Api.Db.Manipulation;
using SmartVac.Api.Db.Vaccine;

namespace SmartVac.Api.Service;

public class VaccinationService : IVaccinationService
{
    public DateTime CalculateNextVaccinationDate(DateTime birthDate, DateTime lastVaccinationDate, long? lastVaccineId,
        IEnumerable<VaccineDbModel> vaccines, List<ManipulationDbModel> manipulations)
    {
        // Получаем возраст ребенка в месяцах
        var ageTimespan = DateTime.Now - birthDate;
        var childAgeInMonths = (int)Math.Floor(ageTimespan.TotalDays / 30.4375); // Среднее количество дней в месяце

        // Сохраняем в отдельную переменную вакцины, которые не подходят по возрасту
        var suitableVaccines = vaccines.Where(v => v.MinAgeInMonth >= childAgeInMonths);

        // Сортируем по возрастанию минимального возраста
        var sortedSuitableVaccines = suitableVaccines.OrderBy(v => v.MinAgeInMonth);

        // Начинаем поиск подходящей вакцины
        foreach (var vaccine in sortedSuitableVaccines)
        {
            // Пропускаем текущую вакцину, если она совпадает с последней сделанной
            if (lastVaccineId.HasValue && vaccine.Id == lastVaccineId.Value)
            {
                continue;
            }

            // Проверяем, была ли данная прививка сделана
            if (!IsVaccineDone(vaccine.Id, manipulations))
            {
                // Рассчитываем дату следующей вакцинации
                var nextVaccinationDate = lastVaccinationDate.AddDays(28);
                return nextVaccinationDate;
            }
        }

        throw new Exception("Все необходимые прививки выполнены.");
    }

    private bool IsVaccineDone(long vaccineId, List<ManipulationDbModel> manipulations)
    {
        return manipulations.Any(m => m.VaccineId == vaccineId);
    }
}