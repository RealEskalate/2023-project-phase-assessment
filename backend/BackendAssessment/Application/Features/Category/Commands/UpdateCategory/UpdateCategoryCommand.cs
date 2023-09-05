using Application.DTOs.Category;
using MediatR;

namespace Application.Features.Category.Commands.UpdateCategory;

public class UpdateCategoryCommand : IRequest<CategoryResponseDto>
{
    public int CategoryId { get; set; }
    public CategoryRequestDto CategoryDto { get; set; } = null!;
}