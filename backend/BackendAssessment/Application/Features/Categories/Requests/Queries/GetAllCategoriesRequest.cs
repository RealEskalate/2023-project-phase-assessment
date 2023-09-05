using MediatR;
using ProductHub.Application.Common.Responses;
using ProductHub.Application.DTOs.CategoryDtos;

namespace ProductHub.Application.Features.Categories.Requests.Queries;

public class GetAllCategoriesRequest : IRequest<CommonResponse<List<CategoryDto>>>
{
}
