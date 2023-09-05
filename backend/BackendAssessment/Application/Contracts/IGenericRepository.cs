using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
       
            Task<T?> Get(int id);
            Task<List<T>> GetAll();
            Task<bool> Exists(int id);
            Task<T> Add(T item);
            Task<T> Update(T item);
            Task Delete(T item);
        
    }
}
