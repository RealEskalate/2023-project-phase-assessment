using ProductHub.Domain.Entities;

namespace ProductHub.Application.Contracts.Persistence;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<IReadOnlyList<Product>> GetProductsByNameAsync(string Name);
    Task<IReadOnlyList<Product>> GetProductsByCategoryIdAsync(int Id);
    Task<IReadOnlyList<Product>> GetProductsByAvailabilityAsync(Availability availability);
    Task<IReadOnlyList<Product>> GetByProductsPriceRangeAsync(double startingPrice, double finalPrice);
}