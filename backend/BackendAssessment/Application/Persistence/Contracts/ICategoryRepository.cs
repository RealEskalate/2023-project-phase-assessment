using Backend.Application.DTOs.Category;
using Backend.Application.DTOs.Product;
using Backend.Domain.Entities;
using ErrorOr;

namespace Backend.Application.Persistence.Contracts;

public interface ICategoriesRepository
{
    Task<ErrorOr<CategoryDto>> PostCategory(Category category);
    Task<ErrorOr<CategoryDto>> GetCategoryById(Guid id);
    Task<ErrorOr<CategoryDto>> GetCategoryByName(string name);
    Task<ErrorOr<CategoryDto>> GetCategoryByDescription(string description);
}