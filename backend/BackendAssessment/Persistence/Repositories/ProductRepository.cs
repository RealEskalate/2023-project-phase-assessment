using BackendAssessment.Application.Contracts.Persistence;
using BackendAssessment.Domain.Entities;

namespace BackendAssessment.Persistence.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    private readonly BackendAssessmentDbContext _dbContext;

    public ProductRepository(BackendAssessmentDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<List<Product>> GetProductsByTagsAsync(List<string> tags)
    {
        var matchingProducts = new List<Product>();

        await foreach (var product in _dbContext.Products.AsAsyncEnumerable())
        {
            if (tags.Any(tag => product.Description.Contains(tag)))
            {
                matchingProducts.Add(product);
            }
        }

        return matchingProducts;
    }
}