
using System.Data;
using Npgsql;

public abstract class BaseRepository
{
    private readonly string _connectionString;

    protected BaseRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected IDbConnection CreateConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}