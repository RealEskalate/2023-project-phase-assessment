using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Product;

namespace Application.Contracts.Persistence
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        // Task<IReadOnlyList<Pro>> GetCommentsByPostId(Guid postId, int pageIndex, int pageSize);
        // Task<IReadOnlyList<Comment>> GetCommentsByUserId(Guid userId, int pageIndex, int pageSize);
    }
}