using Application.DTOs.Category;
using MediatR;

namespace Application.Features.Category.Queries.GetSingleCategory;

public class GetSingleCategoryRequest : IRequest<CategoryResponseDto>
{
    public int Id { get; set; }
}