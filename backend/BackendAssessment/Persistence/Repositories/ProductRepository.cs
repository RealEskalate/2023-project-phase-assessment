using Application.Contracts;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class ProductRepository : GenericRepository<ProductEntity>, IProductRepository
{
    private readonly AppDBContext _dbContext;

    public ProductRepository(AppDBContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ProductEntity?> GetSingleProductWithOwner(int id)
    {
        var product = await _dbContext.Products.Include(p => p.ProductOwner).FirstOrDefaultAsync(p => p.Id == id);
        return product;
    }
}