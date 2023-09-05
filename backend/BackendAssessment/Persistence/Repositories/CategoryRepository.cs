using Application.Contracts;
using Domain.Entites;

namespace Persistence.Repositories;

public class CategoryRepository : GenericRepository<CategoryEntity>, ICategoryRepository
{
    private readonly AppDBContext _dbContext;

    public CategoryRepository(AppDBContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}