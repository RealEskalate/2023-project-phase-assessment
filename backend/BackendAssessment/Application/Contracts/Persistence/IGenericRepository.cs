namespace Application.Contracts.Persistence;

public interface IGenericRepository<T>
{
    Task<T> GetAsync(Guid id);
    Task<List<T>> GetAsync();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(Guid id, T enity);
    Task DeleteAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
}
