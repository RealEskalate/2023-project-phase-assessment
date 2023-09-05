
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Domain.Entites;

namespace Application.Contracts
{
    public interface IProductRepository
    {
        Task<Product> GetProductAsync(int productId);
        Task<IEnumerable<Product>> GetProductsByUserIdAsync(int userId);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int productId);
    }
}
