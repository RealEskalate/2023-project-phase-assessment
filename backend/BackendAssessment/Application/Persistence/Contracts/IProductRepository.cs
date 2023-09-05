using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Persistence.Contracts
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        Task<List<Product>> GetProducts(Guid categoryId);
        Task<List<Product>> GetProductsByuser (Guid userId);
        Task<List<Product>> SearchProduct(string query);
    }
}
