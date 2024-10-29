using System.Data;
using Dapper;

namespace SmartVac.Api.Db.Vaccine;

public class VaccineRepository(string connectionString) : BaseRepository(connectionString), IVaccineRepository
{
    public async Task<VaccineDbModel> GetVaccineByIdAsync(long vaccineId)
    {
        using IDbConnection dbConnection = CreateConnection();
        var queryResult = await dbConnection.QuerySingleOrDefaultAsync<VaccineDbModel>
            ("SELECT * FROM Vaccines WHERE Id = @Id", new { Id = vaccineId });
        return queryResult;
    }

    public async Task<List<long>?> GetVaccinesByChildIdAsync(long childId)
    {
        using IDbConnection dbConnection = CreateConnection();
        var queryResult = await dbConnection.QuerySingleOrDefaultAsync(
            "SELECT VaccineIds FROM Children WHERE Id = @Id", new { Id = childId });
        
        return queryResult;
    }

    public async Task<long> CreateVaccineAsync(VaccineDbModel vaccineDbModel)
    {
        using IDbConnection dbConnection = CreateConnection();
        var sqlQuery = "INSERT INTO Vaccines (Name, Description, MinAgeInMonth) VALUES (@Name, @Description, @MinAgeInMonth) RETURNING Id;";
        return vaccineDbModel.Id = await dbConnection.QuerySingleAsync<long>(sqlQuery, vaccineDbModel);
    }

    public async Task UpdateVaccineAsync(VaccineDbModel vaccineDbModel)
    {
        using IDbConnection dbConnection = CreateConnection();
        var sqlQuery = "UPDATE Vaccines SET Name = @Name, Description = @Description, MinAgeInMonth = @MinAgeInMonth WHERE Id = @Id;";
        await dbConnection.ExecuteAsync(sqlQuery, vaccineDbModel);
    }

    public async Task DeleteVaccineAsync(long vaccineId)
    {
        using IDbConnection dbConnection = CreateConnection();
        var sqlQuery = "DELETE FROM Vaccines WHERE Id = @Id;";
        await dbConnection.ExecuteAsync(sqlQuery, new { Id = vaccineId });
    }
}