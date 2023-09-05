using Application.DTOs.Category;
using MediatR;

namespace Application.Features.Category.Queries.GetSingleCategory;

public class GetSingleCategoryCommand : IRequest<CategoryDto>
{
    public Guid CategoryId { get; set; }
}