using System.Data;
using Dapper;

namespace SmartVac.Api.Db.User;

public class UserRepository : BaseRepository, IUserRepository
{
    public UserRepository(string connectionString) : base(connectionString) { }

    public async Task<UserDbModel> GetUserAsync(long id)
    {
        using IDbConnection dbConnection = CreateConnection();
        return await dbConnection.QuerySingleOrDefaultAsync<UserDbModel>("SELECT * FROM Users WHERE Id = @Id", new { Id = id });
    }

    public async Task<IEnumerable<UserDbModel>> GetAllUsersAsync()
    {
        using IDbConnection dbConnection = CreateConnection();
        return await dbConnection.QueryAsync<UserDbModel>("SELECT * FROM Users");
    }

    public async Task<long> CreateUserAsync(UserDbModel userDbModel)
    {
        using IDbConnection dbConnection = CreateConnection();
        var sqlQuery = "INSERT INTO Users (Name, Email, ChildrenIds) VALUES (@Name, @Email, @ChildrenIds) RETURNING Id;";
        return userDbModel.Id = await dbConnection.QuerySingleAsync<long>(sqlQuery, userDbModel);
    }

    public async Task UpdateUserAsync(UserDbModel userDbModel)
    {
        using IDbConnection dbConnection = CreateConnection();
        var sqlQuery = "UPDATE Users SET Name = @Name, Email = @Email, ChildrenIds = @ChildrenIds WHERE Id = @Id;";
        await dbConnection.ExecuteAsync(sqlQuery, userDbModel);
    }

    public async Task DeleteUserAsync(long id)
    {
        using IDbConnection dbConnection = CreateConnection();
        var sqlQuery = "DELETE FROM Users WHERE Id = @Id;";
        await dbConnection.ExecuteAsync(sqlQuery, new { Id = id });
    }
}