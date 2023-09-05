using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Contracts.Persisitence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> Get(Guid id);
        Task<IReadOnlyList<T>> GetAll(int pageIndex, int pageSize);
        Task<T> Add(T entity);
        Task<bool> Exists(Guid id);
        Task Update(T entity);
        Task Delete(T entity); 
    }
}