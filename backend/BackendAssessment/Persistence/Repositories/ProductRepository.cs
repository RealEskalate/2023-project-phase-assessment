using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(ProductHubDbContext context) : base(context)
    {
    }

    public async Task<IReadOnlyList<Product>> GetByCategory(string categoryName)
    {
        return await _dbSet.Where(p => p.Category.Name == categoryName).ToListAsync();
    }

    public async Task<IReadOnlyList<Product>> SearchByName(string name)
    {
        return await _dbSet.Where(p => p.Name.Contains(name)).ToListAsync();
    }
}