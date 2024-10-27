using SmartVac.Api.Db;
using SmartVac.Api.Db.User;

public interface IUserRepository
{
    Task<UserDbModel> GetUserAsync(long id);
    Task<IEnumerable<UserDbModel>> GetAllUsersAsync();
    Task<long> CreateUserAsync(UserDbModel userDbModel);
    Task UpdateUserAsync(UserDbModel userDbModel);
    Task DeleteUserAsync(long id);
}