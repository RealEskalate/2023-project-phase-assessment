using MediatR;
using ProductHub.Application.Common.Responses;
using ProductHub.Application.DTOs.CategoryDtos;

namespace ProductHub.Application.Features.Categories.Requests.Queries;

public class GetCategoryDetailRequest : IRequest<CommonResponse<CategoryDto>>
{
    public int CategoryId {get; set;}
}
