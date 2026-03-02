using WebAPI_LU2.Models;

namespace WebAPI_LU2.Interfaces
{
    public interface IObject2DRepository
    {   
        Task InsertAsync(Object2D exampleObject);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Object2D>> SelectByEnvironmentAsync(Guid environmentId);
        Task<Object2D?> SelectAsync(Guid id);
        Task UpdateAsync(Object2D exampleObject);
    }
}
