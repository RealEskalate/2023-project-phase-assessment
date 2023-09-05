using BackendAssessment.Domain.Entities;

namespace BackendAssessment.Application.Contracts.Persistence;
public interface IProductRepository : IGenericRepository<Product>
{
    Task<List<Product>> GetByCategory(string categoryName);
    Task<List<Product>> GetByPosterId(int posterId);
}