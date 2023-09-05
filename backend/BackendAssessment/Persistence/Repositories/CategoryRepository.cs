using Application.Contracts;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly ProductHubDbContext _dbContext;

        public CategoryRepository(ProductHubDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CategoryExist(string category)
        {
            var result =  _dbContext.Categories.
                    Where(c => c.Name == category);
                

            return result != null;
        }
    }
}
