using Application.DTOs.Product;
using Domain.Entites;
using Domain.Entites.Products;

namespace Application.Contracts.Persistence;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<List<ProductDetailsDto>> GetProductWithDetails(string userId = "admin");
    Task<ProductDetailsDto> GetProductWithDetails(Guid productId);
    
    
}