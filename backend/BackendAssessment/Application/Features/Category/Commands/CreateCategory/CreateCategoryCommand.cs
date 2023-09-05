using Application.DTOs.Category;
using MediatR;

namespace Application.Features.Category.Commands.CreateCategory;

public class CreateCategoryCommand : IRequest<CategoryDto>
{
    public CategoryReqResDto CategoryReqResDto { get; set; } = null!;
}