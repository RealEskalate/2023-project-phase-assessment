using Application.Contracts.Persistence;
using Domain.Entites;
using Domain.Entites.Products;

namespace Persistence.Repository;

public class ProductRepository : GenericRepository<Product> , IProductRepository
{
    private readonly ProductHubDbContext _dbContext;
    public ProductRepository(ProductHubDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}