using Application.DTOs.Category;
using MediatR;

namespace Application.Features.Category.Commands.UpdateCategory;

public class UpdateCategoryCommand : IRequest<CategoryDto>
{
    public Guid CategoryId { get; set; }
    public CategoryReqResDto CategoryReqResDto { get; set; } = null!;
}