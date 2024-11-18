namespace SmartVac.Api.Db.Manipulation;

public interface IManipulationRepository
{
    Task<long> CreateManipulation(ManipulationDbModel manipulationDbModel);
    Task<ManipulationDbModel> GetManipulationAsync(long id);
    Task<List<ManipulationDbModel>> GetManipulationListByChildIdAsync(long id);
    Task<ManipulationDbModel> UpdateManipulationAsync(ManipulationDbModel manipulationDbModel);
    Task DeleteManipulationAsync(long id);
}