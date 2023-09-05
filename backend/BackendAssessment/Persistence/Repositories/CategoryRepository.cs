using Application.Persistance.Contracts;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICatagoryRepository
    {
        public CategoryRepository(ProductHubDbContext dbContext):base(dbContext)
        {
            
        }
    }
}
