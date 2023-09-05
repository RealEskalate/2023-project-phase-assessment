using Application.Contracts.Persistence;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{   
    private readonly ProductHubDbContext _dbContext;
    
    public CategoryRepository(ProductHubDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Category> GetCategoryByName(string categoryName)
    {
        return await _dbContext.Categories.FirstOrDefaultAsync(c => c.Name == categoryName);
    }
    
}