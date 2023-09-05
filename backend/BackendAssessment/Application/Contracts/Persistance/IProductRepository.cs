using Domain.Entites;

namespace Application.Contracts.Persistance;

public class IProductRepository : IGenericRepository<Product>
{
    Task<List<Product>> GetProductById(int ProductId);
    Task<List<Product>> GetProductByCatagory(Catagory Catagory);
}