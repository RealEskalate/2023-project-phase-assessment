using Application.Contracts;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;

namespace Persistence.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    private readonly AssessmentDbContext _dbContext;
    
    public CategoryRepository(AssessmentDbContext dbContext) : base(dbContext)
    {
        
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<Category>> GetCategoriesWithProductsAsync()
    {
        return await _dbContext.Categories.Include(c => c.Products).ToListAsync();
    }
}