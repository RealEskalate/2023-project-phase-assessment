using Backend.Application.DTOs.Product;
using Backend.Domain.Entities;
using ErrorOr;

namespace Backend.Application.Persistence.Contracts;

public interface IProductRepository{
    Task<Product> PostProduct(Product product);
    Task<Product> GetProductById(Guid id);
    Task<List<Product>> GetProductByName(string name);
    Task<List<Product>> GetProductByCategory(string category);
    Task<List<Product>> GetProductByBrand(string brand);
    Task<List<Product>> GetProductByPrice(decimal price);
}