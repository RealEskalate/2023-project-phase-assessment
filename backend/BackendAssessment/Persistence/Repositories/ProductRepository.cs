using Application.Contracts;
using Domain.Entities;

namespace Persistence.Reposiotories;

public class ProductRepository : GenericReposiotry<Product>, IProductRepository
{
    public ProductRepository(ProductHubDbContext dbContext) : base(dbContext)
    {
    }
}