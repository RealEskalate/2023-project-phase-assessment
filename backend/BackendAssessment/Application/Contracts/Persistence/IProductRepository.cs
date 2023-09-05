using ProductHub.Domain.Entites;

namespace ProductHub.Application.Contracts.Persistence;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<List<Product>> GetProductsByUserId(int userId);
    // Task<List<Product>> GetProductsByCategory(int categoryId);
}
