namespace Application.Contracts.Persistence;

public interface IGenericRepository<T>
{
    Task<T> GetAsync(int id);
    Task<List<T>> GetAsync();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(int id, T enity);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}
