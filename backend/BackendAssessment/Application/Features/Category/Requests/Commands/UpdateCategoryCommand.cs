using Application.Dtos;
using MediatR;

namespace Application.Features.Cateogory.Commands;

public class UpdateCategoryCommand : IRequest<Unit>
{
    public required UpdateCategoryDto UpdateCategoryDto { get; set; }
}