using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Persistance.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(Guid id);
        bool Exists(Guid id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        void  Delete(T entity);
    }
}
