using Domain.Entites;

namespace Application.Contracts;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<IReadOnlyList<Product>> GetProductsByCategoryIdAsync(int categoryId);
    
}