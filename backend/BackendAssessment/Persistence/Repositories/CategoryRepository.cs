using Application.Persistance.Contracts;
using Application.Persistence.Repositories;
using Domain.Entites;
using Infrastructure.Data;

namespace Persistence.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApiDbContext dbContext) : base(dbContext)
        {
        }
    }
}