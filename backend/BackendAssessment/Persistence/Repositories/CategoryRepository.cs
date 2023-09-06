using Application.Contracts.Persistence;
using Domain.Entities.Category;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository{
        private readonly ProductHubDbContext _dbContext;

        public CategoryRepository(ProductHubDbContext  dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        // public async Task<IReadOnlyList<Product>> GetCommentsByPostId(Guid postId, int pageIndex, int pageSize)
        // {
        //     var comments = await _dbContext.Comments.Where(c => c.PostId == postId)
        //                         .OrderByDescending(c => c.CreatedAt)
        //                         .Skip((pageIndex - 1) * pageSize)
        //                         .Take(pageSize)
        //                         .ToListAsync();
        //     return comments;
        // }

        // public async Task<IReadOnlyList<Comment>> GetCommentsByUserId(Guid userId, int pageIndex, int pageSize)
        // {
        //     var comments = await _dbContext.Comments.Where(c => c.UserId == userId)
        //                         .OrderByDescending(c => c.CreatedAt)
        //                         .Skip((pageIndex - 1) * pageSize)
        //                         .Take(pageSize)
        //                         .ToListAsync();
        //     return comments;
        // }
    }
}