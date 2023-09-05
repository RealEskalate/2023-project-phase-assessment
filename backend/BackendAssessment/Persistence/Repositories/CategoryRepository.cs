using Application.Contracts;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class CategoryRepository :  GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ProductListingServiceDbContext dbContext) : base(dbContext)
        {

        }
    }
}
