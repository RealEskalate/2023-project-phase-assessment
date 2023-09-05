using Application.Contracts.Persistence;
using Domain.Entities;

namespace Persistence.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    private ProductHubDbContext _dbContext;

    public ProductRepository(ProductHubDbContext dbContext)
        : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
