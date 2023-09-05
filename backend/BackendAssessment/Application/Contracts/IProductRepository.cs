using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Contracts;
using Domain.Entites;


namespace Application.Contracts;
public interface IProductRepository : IGenericRepository<Product>
{
    Task<List<Product>> GetProducts(int CategoryId);
}
 