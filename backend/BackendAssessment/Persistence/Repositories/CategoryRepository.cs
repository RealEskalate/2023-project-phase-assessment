using Application.Contracts.Persistence;
using Domain.Entites;
using Domain.Entites.Categories;

namespace Persistence.Repository;

public class CategoryRepository : GenericRepository<Category> , ICategoryRepository
{
    private readonly ProductHubDbContext _dbContext;
    public CategoryRepository(ProductHubDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}