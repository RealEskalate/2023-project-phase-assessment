using Application.Common.Responses;
using Application.Features.Categories.Dtos;
using MediatR;

namespace Application.Features.Categories.Queries.Commands;

public class CreateCategoryCommand : IRequest<CommonResponse<Guid>>
{
    public Guid UserId { get; set; }
    public CategoryDto CreateCategoryDto { get; set; } = null!;
}
