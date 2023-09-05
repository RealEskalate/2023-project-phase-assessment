using Application.DTO.ProductDTO.DTO;
using Domain.Entites;
using System.Linq.Expressions;


namespace Application.Contracts
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<Product> Get(int id);

        Task<bool> Exists(int id);

        Task<List<Product>> GetAll(int userId);

    
    }
}
