using Application.Common.Responses;
using Application.Features.Categories.Dtos;
using MediatR;

namespace Application.Features.Categories.Queries.Commands;

public class UpdateCategoryCommand : IRequest<CommonResponse<Unit>>
{
    public int UserId { get; set; }
    public CategoryDto UpdateCategoryDto { get; set; } = null!;
}
