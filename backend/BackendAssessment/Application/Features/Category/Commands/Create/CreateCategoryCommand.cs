
using Application.Dtos.Category;
using MediatR;

namespace Application.Features.Category.Commands.Create;

public class CreateCategoryCommand : IRequest<CategoryResponseDto>
{
    public CategoryRequestDto NewCategory { get; set; } = null!;
}