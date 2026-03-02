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

        public async Task InsertAsync(Environment2D environment2D)
        {
            using (var sqlConnection = new SqlConnection(sqlConnectionString))
            {
                await sqlConnection.ExecuteAsync("INSERT INTO [Environment2D] (Id, OwnerUserId, Name, MaxLength, MaxHeight) VALUES (@Id, @OwnerUserId, @Name, @MaxLength, @MaxHeight)", environment2D);
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
                return await sqlConnection.QueryAsync<Environment2D>("SELECT * FROM [Object2D]");
            }
        }

        public async Task UpdateAsync(Environment2D environment2D)
        {
            using (var sqlConnection = new SqlConnection(sqlConnectionString))
            {
                await sqlConnection.ExecuteAsync("UPDATE [Environment2D] SET " +
                                                 "Name = @Name, " +
                                                 "MaxLength = @MaxLength, " +
                                                 "MaxHeight = @MaxHeight " +
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