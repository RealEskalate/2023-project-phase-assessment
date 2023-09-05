using MediatR;
using ProductHub.Application.DTOs.CategoryDtos;
using ProductHub.Application.Common.Responses;

namespace ProductHub.Application.Features.Categories.Commands.Requests;

public class DeleteCategoryCommand : IRequest<CommonResponse<int>>
{
    public DeleteCategoryDto DeleteCategoryDto { get; set; } = null!;

}
