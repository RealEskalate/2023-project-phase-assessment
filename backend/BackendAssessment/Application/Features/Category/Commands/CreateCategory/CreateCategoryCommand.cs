using Application.DTOs.Category;
using Application.DTOs.Product;
using Application.Responses;
using MediatR;

namespace Application.Features.Category.Commands.CreateCategory;

public class CreateCategoryCommand : IRequest<BaseCommandResponse>
{
    public CreateCategoryDto Category { get; set; }
}
