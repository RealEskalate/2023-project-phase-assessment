using MediatR;
using ProductHub.Application.Common.Responses;
using ProductHub.Application.DTOs.CategoryDtos;

namespace ProductHub.Application.Features.Categories.Queries.Requests;
public class GetAllCategoriesQuery : IRequest<CommonResponse<List<CategoryDto>>>
{

}
