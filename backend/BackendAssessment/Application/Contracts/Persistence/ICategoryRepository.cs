using Domain.Entites;

namespace Application.Contracts.Persistence;

public interface ICategoryRepository : IGenericRepository<Category>
{
    public Task<Category> GetCategoryByName(string categoryName);
}