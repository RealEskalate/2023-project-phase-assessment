using Domain.Entites;

namespace Application.Contracts
{
    public interface IProductRepository
    {
        Task<Product> GetProductById(int id);
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task<Product> DeleteProduct(Product product);
        Task<List<Product>> GetAllProducts();
        Task<bool> Exists(int id);
        
    }
}