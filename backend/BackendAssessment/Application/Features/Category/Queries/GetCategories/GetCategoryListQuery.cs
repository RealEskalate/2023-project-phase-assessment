using Application.DTOs.Category;
using MediatR;

namespace Application.Features.Category.Queries.GetCategories;

public class GetCategoryListQuery : IRequest<List<CategoryDetailsDto>>
{
}
