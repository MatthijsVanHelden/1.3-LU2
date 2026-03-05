using WebAPI_LU2.Models;

namespace WebAPI_LU2.Interfaces
{
    public interface IEnvironment2DRepository
    {
        Task<List<Environment2D>> SelectByOwnerAsync(string ownerEmail);
        Task InsertAsync(Environment2D exampleObject);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Environment2D>> SelectAsync();
        Task<Environment2D?> SelectAsync(Guid id);
        Task UpdateAsync(Environment2D exampleObject);
    }
}
