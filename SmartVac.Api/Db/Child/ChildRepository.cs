using System.Data;
using System.Diagnostics;
using Dapper;
using Npgsql;
using SmartVac.Api.Db.Child;

public class ChildRepository : BaseRepository, IChildRepository
{
    public ChildRepository(string connectionString) : base(connectionString) { }

    public Task<long> CreateChildAsync(Child child)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteChildAsync(long id)
    {
        using IDbConnection dbConnection = CreateConnection();
        var sqlQuery = "DELETE FROM Children WHERE Id = @Id;";
        await dbConnection.ExecuteAsync(sqlQuery, new { Id = id });
    }

    public async Task<Child> GetChildAsync(long id)
    {
        using IDbConnection dbConnection = CreateConnection();
        var sqlQuery = "SELECT * FROM Children WHERE Id = @Id";
        return await dbConnection.QuerySingleOrDefaultAsync<Child>(sqlQuery, new { Id = id });
    }

    public async Task<List<Child>> GetChildListByParentIdAsync(long userId)
    {
        using IDbConnection dbConnection = CreateConnection();
        var sqlQuery = "SELECT * FROM Children WHERE ParentId = @Id";
        var children = await dbConnection.QueryAsync<Child>(sqlQuery, new { Id = userId });
        return children.ToList();
    }

    public async Task<Child> UpdateChildAsync(Child child)
    {
        using IDbConnection dbConnection = CreateConnection();
        var sqlQuery = "UPDATE Children SET Name = @Name, BirthDate = @BirthDate, Gender = @Gender, ParentId = @ParentId, NextVacId = @NextVacId, NextVacDate = @NextVacDate, LastManipulationId = @LastManipulationId WHERE Id = @Id;";
        await dbConnection.ExecuteAsync(sqlQuery, child);
        return await GetChildAsync(child.Id);
    }
}