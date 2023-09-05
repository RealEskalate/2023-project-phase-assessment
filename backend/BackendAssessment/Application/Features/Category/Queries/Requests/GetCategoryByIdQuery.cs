using MediatR;
using ProductHub.Application.Common.Responses;
using ProductHub.Application.DTOs.CategoryDtos;

namespace ProductHub.Application.Features.Categories.Queries.Requests;
public class GetCategoryByIdQuery : IRequest<CommonResponse<CategoryDto>>
{
    public int Id { get; set; }
}