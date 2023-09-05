using Application.Contracts.Persistence;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{   
    private readonly ProductHubDbContext _dbContext;
    
    public ProductRepository(ProductHubDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Product> SearchProductByName(string productName)
    {
        return await _dbContext.Products.FirstOrDefaultAsync(p => p.Name == productName);
    }
    
    public async Task<Product> SearchProductByCategory(string categoryName)
    {
        return await _dbContext.Products.FirstOrDefaultAsync(p => p.Category.Name == categoryName);
    }
}