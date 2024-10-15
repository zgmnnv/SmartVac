using Dapper;
using Npgsql;
using SmartVac.Api.Db;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

public class UserRepository : IUserRepository
{
    private readonly string _connectionString;

    public UserRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<User> GetUserAsync(long id)
    {
        using IDbConnection dbConnection = new NpgsqlConnection(_connectionString);
        dbConnection.Open();
        return await dbConnection.QuerySingleOrDefaultAsync<User>("SELECT * FROM Users WHERE Id = @Id", new { Id = id });
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        using IDbConnection dbConnection = new NpgsqlConnection(_connectionString);
        dbConnection.Open();
        return await dbConnection.QueryAsync<User>("SELECT * FROM Users");
    }

    public async Task<long> CreateUserAsync(User user)
    {
        using IDbConnection dbConnection = new NpgsqlConnection(_connectionString);
        dbConnection.Open();
        var sqlQuery = "INSERT INTO Users (Name, Email, ChildrenIds) VALUES (@Name, @Email, @ChildrenIds) RETURNING Id;";
        return user.Id = await dbConnection.QuerySingleAsync<long>(sqlQuery, user);
    }

    public async Task UpdateUserAsync(User user)
    {
        using IDbConnection dbConnection = new NpgsqlConnection(_connectionString);
        dbConnection.Open();
        var sqlQuery = "UPDATE Users SET Name = @Name, Email = @Email, ChildrenIds = @ChildrenIds WHERE Id = @Id;";
        await dbConnection.ExecuteAsync(sqlQuery, user);
    }

    public async Task DeleteUserAsync(long id)
    {
        using IDbConnection dbConnection = new NpgsqlConnection(_connectionString);
        dbConnection.Open();
        var sqlQuery = "DELETE FROM Users WHERE Id = @Id;";
        await dbConnection.ExecuteAsync(sqlQuery, new { Id = id });
    }
}
