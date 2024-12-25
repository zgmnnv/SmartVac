using System.Data;
using Dapper;

namespace SmartVac.Api.Db.User;

public class UserRepository : BaseRepository, IUserRepository
{
    public UserRepository(string connectionString) : base(connectionString) { }

    public async Task<UserDbModel> GetUserAsync(long id)
    {
        using IDbConnection dbConnection = CreateConnection();
        return await dbConnection.QuerySingleOrDefaultAsync<UserDbModel>("SELECT * FROM users WHERE Id = @Id", new { Id = id });
    }

    public async Task<IEnumerable<UserDbModel>> GetAllUsersAsync()
    {
        using IDbConnection dbConnection = CreateConnection();
        return await dbConnection.QueryAsync<UserDbModel>("SELECT * FROM users");
    }

    public async Task<long> CreateUserAsync(UserDbModel userDbModel)
    {
        using IDbConnection dbConnection = CreateConnection();
        var sqlQuery = "INSERT INTO users (name, email, password, childrenIds) VALUES (@Name, @Email, @Password, @ChildrenIds) RETURNING Id;";
        return userDbModel.Id = await dbConnection.QuerySingleAsync<long>(sqlQuery, userDbModel);
    }

    public async Task UpdateUserAsync(UserDbModel userDbModel)
    {
        using IDbConnection dbConnection = CreateConnection();
        var sqlQuery = "UPDATE users SET name = @Name, email = @Email, childrenIds = @ChildrenIds WHERE Id = @Id;";
        await dbConnection.ExecuteAsync(sqlQuery, userDbModel);
    }

    public async Task DeleteUserAsync(long id)
    {
        using IDbConnection dbConnection = CreateConnection();
        var sqlQuery = "DELETE FROM users WHERE id = @Id;";
        await dbConnection.ExecuteAsync(sqlQuery, new { Id = id });
    }
}