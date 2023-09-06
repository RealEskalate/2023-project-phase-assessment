using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Persisitence;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ProductHubDbContext _dbContext;

        public ProductRepository(ProductHubDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<Product>> FilterProductsByCatagoryId(Guid catagoryId, int pageIndex, int pageSize)
        {
            return await _dbContext.Products.Where(p => p.CatagoryId == catagoryId)
                        .OrderByDescending(p => p.CreatedAt)
                        .Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync();
        }

        public async Task<IReadOnlyList<Product>> SearchProductsByName(string name, int pageIndex, int pageSize)
        {
            return await _dbContext.Products.Where(p => p.Name.Contains(name))
                        .OrderByDescending(p => p.CreatedAt)
                        .Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync();
        }
    }
}