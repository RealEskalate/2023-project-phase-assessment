using Application.Contracts;
using Domain.Entities;

namespace Persistence.Reposiotories;

public class CategoryRepository : GenericReposiotry<Category>, ICategoryRepository
{
    public CategoryRepository(ProductHubDbContext dbContext) : base(dbContext)
    {
    }
}