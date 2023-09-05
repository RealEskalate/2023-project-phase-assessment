using Domain.Entities;

namespace Application.Contracts.Persistence;

public interface ICategoryRepository : IGenericRepository<Category>
{
    public Task<int> GetCategoryId(string categoryName);
}