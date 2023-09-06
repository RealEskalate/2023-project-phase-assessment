using Domain.Entites;

namespace Application.Contracts
{
    public interface ICategoryRepository
    {
        Task<Category> GetCategoryById(int id);
        Task<Category> GetCategoryByName(string name);
        Task<Category> AddCategory(Category category);
        Task<Category> UpdateCategory(Category category);
        Task<List<Category>> GetAllCategories();
        Task<bool> Exists(int id);
        
    }
}