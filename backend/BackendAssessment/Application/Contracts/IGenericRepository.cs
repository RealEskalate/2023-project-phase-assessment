using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IGenericRepository<T>
    {
        public Task<T> Add(T entity);
        public Task<bool> Delete(T entity);
        public Task<T> Update(T entity);

        public Task<T> GetbyId(int id);

        public Task<List<T>> GetAll();

        public Task<bool> Exists(int id);
    }
}
