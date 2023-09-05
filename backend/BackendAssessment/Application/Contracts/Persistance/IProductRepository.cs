using Domain.Entites;

namespace Application.Contracts.Persistance;

public interface IProductRepository: IGenericRepository<Product>{
    
    Task<List<Product>> Search(string name, int pageNumber = 0, int pageSize = 10);

    
}