using Domain.Entites;

namespace Application.Contracts;

public interface ICategoryRepository : IGenericRepository<Category>
{
    Task<IReadOnlyList<Category>> GetCategoriesWithProductsAsync();
}