using System.Data;
using Dapper;
using Npgsql;
using SmartVac.Api.Db.Child;

public class ChildRepository : BaseRepository, IChildRepository
{
    public ChildRepository(string connectionString) : base(connectionString) { }

    public Task<long> CreateChildAsync()
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

    public Task<List<Child>> GetChildListByParentIdAsync(long userId)
    {
        using IDbConnection dbConnection = CreateConnection();
        var sqlQuery = "SELECT * FROM Children WHERE ParentId = @Id";
        return dbConnection.QuerySingleOrDefaultAsync<List<Child>>(sqlQuery,new { Id = userId});
    }

    public Task<Child> UpdateChildAsync(Child child)
    {
        throw new NotImplementedException();
    }
}