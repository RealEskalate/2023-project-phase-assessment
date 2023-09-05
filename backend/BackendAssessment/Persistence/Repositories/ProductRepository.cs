using Application.Contracts.Persistence;
using Application.DTOs.Product;
using Domain.Entites;
using Domain.Entites.Categories;
using Domain.Entites.Products;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository;

public class ProductRepository : GenericRepository<Product> , IProductRepository
{
    private readonly ProductHubDbContext _dbContext;
    public ProductRepository(ProductHubDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ProductDetailsDto>> GetProductWithDetails(string userId = "admin")
    {
        var products = new List<Product>();
        if (userId == "admin")
        {
            // select all products and also add the category by using include
            products = await _dbContext.Products.Include(p => p.Category).ToListAsync();
        }
        else
        {
            products = await _dbContext.Products
                .Where(p => p.UserId == new Guid(userId))
                .Include(p => p.Category)
                .ToListAsync();
        }

        return products.Select(product => new ProductDetailsDto()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Category = product.Category!,
                CategoryId = product.CategoryId
            })
            .ToList();
    }

    public async Task<ProductDetailsDto> GetProductWithDetails(Guid productId)
    {
        var product =  await _dbContext.Products
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Id == productId);

        return new ProductDetailsDto()
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Category = product.Category!,
            CategoryId = product.CategoryId
        };
    }
}   