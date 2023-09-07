using BackendAssessment.Domain.Entities;

namespace BackendAssessment.Application.Contracts.Persistence;

public interface IProductRepository: IGenericRepository<Product>
{
    Task<List<Product>> GetProductsByTagsAsync(List<string> tags);

    
}