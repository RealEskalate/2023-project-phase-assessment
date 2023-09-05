using Domain.Entites;

namespace Application.Contracts.Persistance;

public class ICatagoryRepository : IGenericRepository<Catagory>
{
    Task<List<Catagory> GetCatagoryById(int Id, int pageNumber = 0, int pageSize = 10);
}