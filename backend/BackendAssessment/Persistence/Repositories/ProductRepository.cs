using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts;
using Domain;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductHubDbContext _dbContext;

        public ProductRepository(ProductHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> GetProductAsync(int productId)
        {
            return await _dbContext.Products.FindAsync(productId);
        }

        public async Task<IEnumerable<Product>> GetProductsByUserIdAsync(int userId)
        {
            return await _dbContext.Products.Where(p => p.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task CreateProductAsync(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int productId)
        {
            var product = await _dbContext.Products.FindAsync(productId);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
