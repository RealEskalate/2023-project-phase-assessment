using Domain.Entites;

namespace Application.Contracts.Persistance;

public interface ICategoryRepository: IGenericRepository<Category>{
    
    Task<List<Category>> Search(string name, int pageNumber = 0, int pageSize = 10);
    
    
}