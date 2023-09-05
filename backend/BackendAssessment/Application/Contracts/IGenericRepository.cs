namespace Application.Contracts;

public interface IGenericRepository<T> where T : class
{
    Task<T> Get(int id);
    Task<IReadOnlyList<T>> GetAll();
    Task<int> Add(T entity);
    Task<T> Update(T entity);
    Task<T> Delete(T entity);
     
}
