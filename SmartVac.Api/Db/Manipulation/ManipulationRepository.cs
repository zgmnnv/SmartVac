namespace SmartVac.Api.Db.Manipulation;

public class ManipulationRepository(string connectionString) : BaseRepository(connectionString), IManipulationRepository
{
    public Task<long> CreateManipulation(ManipulationDbModel manipulationDbModel)
    {
        throw new NotImplementedException();
    }

    public Task<ManipulationDbModel> GetManipulationAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<List<ManipulationDbModel>> GetManipulationListByChildIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<ManipulationDbModel> UpdateManipulationAsync(ManipulationDbModel manipulationDbModel)
    {
        throw new NotImplementedException();
    }

    public Task DeleteManipulationAsync(long id)
    {
        throw new NotImplementedException();
    }
}