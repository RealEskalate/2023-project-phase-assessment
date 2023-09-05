using Application.DTOs.Category;
using MediatR;

namespace Application.Features.Category.Queries.GetAllCategories;

public class GetAllCategoriesRequest : IRequest<List<CategoryResponseDto>>
{
    
}