using Application.Common.Responses;
using Application.Features.Categories.Dtos;
using MediatR;

namespace Application.Features.Categories.Queries.Commands;

public class CreateCategoryCommand : IRequest<CommonResponse<int>>
{
    public int UserId { get; set; }
    public CategoryDto CreateCategoryDto { get; set; } = null!;
}
