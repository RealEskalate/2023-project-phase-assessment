using Microsoft.EntityFrameworkCore;
using ProductHub.Application.Contracts.Persistence;
using ProductHub.Domain.Entities;

namespace ProductHub.Persistence.Repositories;
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        
        public CategoryRepository(ProductHubDbContext dbContext) : base(dbContext)
        {
        }

       
    }

