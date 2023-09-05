using MediatR;
using ProductHub.Application.Common.Responses;
using ProductHub.Application.DTOs.CategoryDtos;

namespace ProductHub.Application.Features.Categories.Requests.Commands;

public class UpdateCategoryCommand : IRequest<CommonResponse<int>>
{
    public required CategoryUpdateDto CategoryUpdateDto {get; set;}
}
