using Dapper;
using Microsoft.Data.SqlClient;
using WebAPI_LU2.Interfaces;
using WebAPI_LU2.Models;

namespace WebAPI_LU2.Repositories
{
    public class Environment2DRepository : IEnvironment2DRepository
    {
        private readonly string sqlConnectionString;
        
        public Environment2DRepository(string sqlConnectionString)
        {
            this.sqlConnectionString = sqlConnectionString;
        }
        public async Task<List<Environment2D>> SelectByOwnerAsync(string ownerEmail)
        {
            using var connection = new SqlConnection(sqlConnectionString);
            var sql = "SELECT * FROM [dbo].[Environment2D] WHERE OwnerEmail = @OwnerEmail";

            var result = await connection.QueryAsync<Environment2D>(sql, new { OwnerEmail = ownerEmail });
            return result.ToList();
        }

        public async Task InsertAsync(Environment2D environment2D)
        {
            using (var sqlConnection = new SqlConnection(sqlConnectionString))
            {
                await sqlConnection.ExecuteAsync("INSERT INTO [Environment2D] (Id, OwnerEmail, Name) VALUES (@Id, @OwnerEmail, @Name)", environment2D);
            }
        }

        public async Task<Environment2D?> SelectAsync(Guid id)
        {
            using (var sqlConnection = new SqlConnection(sqlConnectionString))
            {
                return await sqlConnection.QuerySingleOrDefaultAsync<Environment2D>("SELECT * FROM [Environment2D] WHERE Id = @Id", new { id });
            }
        }

        public async Task<IEnumerable<Environment2D>> SelectAsync()
        {
            using (var sqlConnection = new SqlConnection(sqlConnectionString))
            {
                return await sqlConnection.QueryAsync<Environment2D>("SELECT * FROM [Environment2D]");
            }
        }

        public async Task UpdateAsync(Environment2D environment2D)
        {
            using (var sqlConnection = new SqlConnection(sqlConnectionString))
            {
                await sqlConnection.ExecuteAsync("UPDATE [Environment2D] SET " +
                                                 "Name = @Name, " +
                                                 "WHERE Id = @Id", environment2D);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            using (var sqlConnection = new SqlConnection(sqlConnectionString))
            {
                await sqlConnection.ExecuteAsync("DELETE FROM [Environment2D] WHERE Id = @Id", new { id });
            }
        }
    }
}