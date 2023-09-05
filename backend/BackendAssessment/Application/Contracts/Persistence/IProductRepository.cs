using Domain.Entities;

namespace Application.Contracts.Persistence;

public interface IProductRepository : IGenericRepository<Product>
{
    public Task<IReadOnlyList<Product>> GetByCategory(string categoryName);
    public Task<IReadOnlyList<Product>> SearchByName(string name);
}