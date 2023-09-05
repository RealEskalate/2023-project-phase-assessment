using Application.DTOs.Category;
using Application.DTOs.Product;
using MediatR;

namespace Application.Features.Category.Commands.UpdateCategory;

public class UpdateCategoryCommand : IRequest<Unit>
{
    public CategoryDetailsDto Category { get; set; }
}
