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

    public new async Task<Guid> AddAsync(Product entity)
    {
        _dbContext.Entry(entity).Collection(p => p.Categories).Load();

        _dbContext.Products.Add(entity);

        await _dbContext.SaveChangesAsync();

        return entity.Id;
    }
}
