using System.Data;
using Dapper;
using SmartVac.Api.Dto.Child;

namespace SmartVac.Api.Db.Child;

public class ChildRepository(string connectionString) : BaseRepository(connectionString), IChildRepository
{
    public async Task<long> CreateChildAsync(ChildDbModel childDbModel)
    {
        using IDbConnection dbConnection = CreateConnection();
        var sqlQuery = "INSERT INTO children (Name, BirthDate, ParentId, NextVacId, NextVacDate, LastManipulationId) VALUES (@Name, @BirthDate, @ParentId, @NextVacId, @NextVacDate, @LastManipulationId) RETURNING Id;";
        return childDbModel.Id = await dbConnection.QuerySingleAsync<long>(sqlQuery, childDbModel);
    }

    public async Task DeleteChildAsync(long id)
    {
        using IDbConnection dbConnection = CreateConnection();
        var sqlQuery = "DELETE FROM children WHERE Id = @Id;";
        await dbConnection.ExecuteAsync(sqlQuery, new { Id = id });
    }

    public async Task<ChildDbModel> GetChildAsync(long id)
    {
        using IDbConnection dbConnection = CreateConnection();
        var sqlQuery = "SELECT * FROM children WHERE Id = @Id";
        return await dbConnection.QuerySingleOrDefaultAsync<ChildDbModel>(sqlQuery, new { Id = id });
    }

    public async Task<List<ChildDbModel>> GetChildListByParentIdAsync(long userId)
    {
        using IDbConnection dbConnection = CreateConnection();
        var sqlQuery = "SELECT * FROM children WHERE ParentId = @Id";
        var children = await dbConnection.QueryAsync<ChildDbModel>(sqlQuery, new { Id = userId });
        return children.ToList();
    }

    public async Task<ChildDbModel> UpdateChildAsync(ChildDbModel childDbModel)
    {
        using IDbConnection dbConnection = CreateConnection();
        var sqlQuery = "UPDATE children SET Name = @Name, BirthDate = @BirthDate, ParentId = @ParentId, NextVacId = @NextVacId, NextVacDate = @NextVacDate, LastManipulationId = @LastManipulationId WHERE Id = @Id;";
        await dbConnection.ExecuteAsync(sqlQuery, childDbModel);
        return await GetChildAsync(childDbModel.Id);
    }
}