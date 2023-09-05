using Application.Common.Responses;
using Application.Features.Categories.Dtos;
using MediatR;

namespace Application.Features.Categories.Queries.Requests;

public class GetAllCategoriesRequest : IRequest<CommonResponse<List<CategoryDto>>> { }
