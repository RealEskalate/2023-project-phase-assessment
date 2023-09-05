using Application.DTOs.Category;
using MediatR;

namespace Application.Features.Category.Queries.GetAllCategories;

public class GetAllCategoriesCommand : IRequest<List<CategoryDto>>
{
    
}