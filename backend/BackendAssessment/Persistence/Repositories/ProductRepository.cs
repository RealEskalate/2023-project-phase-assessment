using Microsoft.EntityFrameworkCore;
using ProductHub.Application.Contracts.Persistence;
using ProductHub.Domain.Entities;

namespace ProductHub.Persistence.Repositories;
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        
        public ProductRepository(ProductHubDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IReadOnlyList<Product>> GetProductsByNameAsync(string name)
        {
            return await _dbContext.Products
                .Where(p => p.Name == name)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<Product>> GetProductsByCategoryIdAsync(int id)
        {
            return await _dbContext.Products
                .Where(p => p.CategoryId == id)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<Product>> GetProductsByAvailabilityAsync(Availability availability)
        {
            return await _dbContext.Products
                .Where(p => p.Availability == availability)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<Product>> GetByProductsPriceRangeAsync(double startingPrice, double finalPrice)
        {
            return await _dbContext.Products
                .Where(p => p.Pricing >= startingPrice && p.Pricing <= finalPrice)
                .ToListAsync();
        }
    }

