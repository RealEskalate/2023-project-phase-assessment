using Application.Contracts;
using Domain.Entites;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ProductHubDbContext _dbContext;

        public ProductRepository(ProductHubDbContext dbContext) : base (dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Product>> GetProductsByCategory(string category)
        {
            var result = _dbContext.Products.
                    Where(p => p.Category.Name == category).
                    ToList();
            return result;
        }
    }
}
