
using Application.Dtos.Category;
using MediatR;

namespace Application.Features.Category.Commands.Update;

public class UpdateCategoryCommand : IRequest<CategoryResponseDto>
{
    public Guid CategoryId { get; set; }
    public CategoryRequestDto UpdateCategory { get; set; } = null!;
}