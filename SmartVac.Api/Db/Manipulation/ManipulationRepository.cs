using System.Data;
using Dapper;

namespace SmartVac.Api.Db.Manipulation;

public class ManipulationRepository(string connectionString) : BaseRepository(connectionString), IManipulationRepository
{
    public async Task<long> CreateManipulation(ManipulationDbModel manipulationDbModel)
    {
        using IDbConnection dbConnection = CreateConnection();
        var sqlQuery = "INSERT INTO Manipulations (Date, ChildId, VaccineId, Description) VALUES (@Date, @ChildId, @VaccineId, @Description) RETURNING Id;";
        return manipulationDbModel.Id = await dbConnection.QuerySingleAsync(sqlQuery, manipulationDbModel);
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