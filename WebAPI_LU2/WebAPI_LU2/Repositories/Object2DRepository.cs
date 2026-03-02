using Dapper;
using Microsoft.Data.SqlClient;
using WebAPI_LU2.Interfaces;
using WebAPI_LU2.Models;

public class Object2DRepository : IObject2DRepository
{
    private readonly string sqlConnectionString;

    public Object2DRepository(string sqlConnectionString)
    {
        this.sqlConnectionString = sqlConnectionString;
    }

    public async Task InsertAsync(Object2D object2D)
    {
        using (var sqlConnection = new SqlConnection(sqlConnectionString))
        {
            await sqlConnection.ExecuteAsync(@"INSERT INTO [Object2D] 
                (Id, Environment2DId, PrefabId, PositionX, PositionY, ScaleX, ScaleY, RotationZ, SortingLayer) 
                VALUES (@Id, @Environment2DId, @PrefabId, @PositionX, @PositionY, @ScaleX, @ScaleY, @RotationZ, @SortingLayer)", object2D);
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        using (var sqlConnection = new SqlConnection(sqlConnectionString))
        {
            await sqlConnection.QueryAsync("DELETE FROM [Object2D] WHERE Id = @Id", new { id });
        }
    }

    public async Task<IEnumerable<Object2D>> SelectByEnvironmentAsync(Guid environment2DId)
    {
        using (var sqlConnection = new SqlConnection(sqlConnectionString))
        {
            return await sqlConnection.QueryAsync<Object2D>(
                "SELECT * FROM [Object2D] WHERE Environment2DId = @Environment2DId",
                new { Environment2DId = environment2DId });
        }
    }

    public async Task<Object2D?> SelectAsync(Guid id)
    {
        using (var sqlConnection = new SqlConnection(sqlConnectionString))
        {
            return await sqlConnection.QuerySingleOrDefaultAsync<Object2D>(
                "SELECT * FROM [Object2D] WHERE Id = @Id", new { id });
        }
    }

    public async Task UpdateAsync(Object2D object2D)
    {
        using (var sqlConnection = new SqlConnection(sqlConnectionString))
        {
            await sqlConnection.ExecuteAsync(@"UPDATE [Object2D] SET 
                                             PositionX = @PositionX, 
                                             PositionY = @PositionY, 
                                             ScaleX = @ScaleX, 
                                             ScaleY = @ScaleY 
                                             WHERE Id = @Id", object2D);
        }
    }
}