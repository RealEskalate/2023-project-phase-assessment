using Application.Contracts;
using Domain.Entities;

namespace Persistence.Repositories;

public class CategoryRepository : GenericRepository<CategoryEntity>, ICategoryRepository
{
    public CategoryRepository(AppDBContext dbContext) : base(dbContext)
    {
    }
}