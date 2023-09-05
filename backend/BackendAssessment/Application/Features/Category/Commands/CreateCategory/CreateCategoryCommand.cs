using Application.DTOs.Category;
using MediatR;

namespace Application.Features.Category.Commands.CreateCategory;

public class CreateCategoryCommand : IRequest<CategoryResponseDto>
{
    public CategoryRequestDto CategoryDto { get; set; } = null!;
}