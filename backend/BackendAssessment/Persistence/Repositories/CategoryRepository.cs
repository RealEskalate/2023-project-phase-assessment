using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(ProductHubDbContext context) : base(context)
    {
    }

    public async Task<int> GetCategoryId(string categoryName)
    {
        var category = await _dbSet.FirstOrDefaultAsync(c => c.Name == categoryName);
        if (category == null)
            return 0;

        return category.Id;
    }
}