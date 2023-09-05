using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Persistence.Contracts
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {
        Task<List<Category>> GetCategory(Guid id);
    }
}
