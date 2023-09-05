using Application.Contracts.Persistance;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories;
using Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ProductHubDbContext _dbContext;
        public ProductRepository(ProductHubDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId)
        {
            return await _dbContext.Products
                .Where(p => p.ProductCategories.Any(pc => pc.CategoryId == categoryId))
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> SearchProducts(string searchTerm)
        {
            return await _dbContext.Products
                .Where(p => p.Name.Contains(searchTerm) || p.Description.Contains(searchTerm))
                .ToListAsync();
        }
    }
}
