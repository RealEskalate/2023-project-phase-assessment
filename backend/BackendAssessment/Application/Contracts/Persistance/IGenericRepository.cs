namespace Application.Contracts.Persistance;

public class IGenericRepository<T> where T : class
{
    private IQueryable<T> Entitites { get; }
    
    Task<T?> Get(int id);
    Task<List<T>> GetAll(int pageNumber= 0, int pageSize= 10);
    Task<bool> Exists(int id);
    Task<T> Add(T entity);
    Task Update(T entity);
    Task Delete(T entity);
}