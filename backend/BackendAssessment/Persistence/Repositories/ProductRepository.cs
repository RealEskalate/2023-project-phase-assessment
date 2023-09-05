using Application.Contracts;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;

namespace Persistence.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    private readonly AssessmentDbContext _dbContext;
    public ProductRepository(AssessmentDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<Product>> GetProductsByCategoryIdAsync(int categoryId)
    {
        return await _dbContext.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
    }
}