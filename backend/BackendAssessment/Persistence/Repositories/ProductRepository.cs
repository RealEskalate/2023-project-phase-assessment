using Microsoft.EntityFrameworkCore;
using ProductHub.Application.Contracts.Persistence;
using ProductHub.Domain.Entites;

namespace ProductHub.Persistence.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    private readonly ProductHubDbContext _dbContext;
    public ProductRepository(ProductHubDbContext dbContext)
        : base(dbContext) { 
            _dbContext = dbContext;
        }
    
    public async Task<List<Product>> GetProductsByUserId(int userId){
        return await _dbContext.Set<Product>()
            .Where(p => p.UserId == userId)
            .ToListAsync(); 
    }
}
