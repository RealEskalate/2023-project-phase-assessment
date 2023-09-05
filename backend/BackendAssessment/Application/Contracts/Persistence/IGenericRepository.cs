namespace Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : class
{
    public Task<IReadOnlyList<T>> GetAll();
    public Task<T?> Get(int id);
    public Task<bool> Exists(int id);
    public Task<T> Update(T item);
    public Task<T> Add(T item);
    public Task Delete(T item);
}