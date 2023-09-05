using Application.Contracts.Persistence;
using Domain.Entities;

namespace Persistence.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    private ProductHubDbContext _dbContext;

    public CategoryRepository(ProductHubDbContext dbContext)
        : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
