using MediatR;
using ProductHub.Application.Common.Responses;
using ProductHub.Application.DTOs.CategoryDtos;

namespace ProductHub.Application.Features.Categories.Requests.Commands;

public class CreateCategoryCommand : IRequest<CommonResponse<int>>
{
    public required CategoryCreateDto CategoryCreateDto {get; set;}
}
