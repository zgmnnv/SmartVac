using SmartVac.Api.Db;

public interface IUserRepository
{
    Task<User> GetUserAsync(long id);
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<long> CreateUserAsync(User user);
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(long id);
}