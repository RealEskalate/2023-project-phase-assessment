using Domain.Entites;

namespace Application.Contracts.Persistence;

public interface IProductRepository : IGenericRepository<Product>
{
    public Task<Product> SearchProductByName(string productName);
    public Task<Product> SearchProductByCategory(string categoryName);
    
}