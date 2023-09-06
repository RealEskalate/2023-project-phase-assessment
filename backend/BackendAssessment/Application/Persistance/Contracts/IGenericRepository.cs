namespace Application.Persistance.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(Guid id);
        Task<List<T>> GetAll();
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        bool Exists(Guid Id);
        void Delete(T entity);

    }
}