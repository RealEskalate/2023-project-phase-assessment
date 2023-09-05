using MediatR;
using ProductHub.Application.DTOs.CategoryDtos;
using ProductHub.Application.Common.Responses;

namespace ProductHub.Application.Features.Categories.Commands.Requests;

public class UpdateCategoryCommand : IRequest<CommonResponse<int>>
{
    public UpdateCategoryDto UpdateCategoryDto { get; set; } = null!;

}
