using Application.Dtos.Category;
using MediatR;

namespace Application.Features.Category.Queries.GetSingle;

public class GetSingleCategoryRequest : IRequest<CategoryResponseDto>
{
    public Guid CategoryId { get; set; }
}