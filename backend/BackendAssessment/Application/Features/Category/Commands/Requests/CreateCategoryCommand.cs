using MediatR;
using ProductHub.Application.DTOs.CategorydDtos;
using ProductHub.Application.Common.Responses;
using ProductHub.Application.DTOs.CategoryDtos;

namespace ProductHub.Application.Features.Categories.Commands.Requests;

public class CreateCategoryCommand : IRequest<CommonResponse<int>>
{
    public CreateCategoryDto CreateCategoryDto { get; set; } = null!;

}
