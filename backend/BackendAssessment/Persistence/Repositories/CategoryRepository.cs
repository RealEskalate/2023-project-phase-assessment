using ProductHub.Application.Contracts.Persistence;
using ProductHub.Domain.Entites;

namespace ProductHub.Persistence.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    private readonly ProductHubDbContext _dbContext;
    public CategoryRepository(ProductHubDbContext dbContext)
        : base(dbContext) { 
            _dbContext = dbContext;
        }
}
