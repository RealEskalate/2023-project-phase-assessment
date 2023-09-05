using Application.Contracts;
using Domain.Entities;

namespace Persistence.Repositories;

public class ProductRepository : GenericRepository<ProductEntity>, IProductRepository
{
    public ProductRepository(AppDBContext dbContext) : base(dbContext)
    {
    }
}