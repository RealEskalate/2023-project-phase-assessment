

using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Domain.Entites;

namespace Application.Contracts
{
    public interface ICategoryRepository
    {
        Task<Category> GetCategoryAsync(int categoryId);
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task CreateCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(int categoryId);
    }
}
