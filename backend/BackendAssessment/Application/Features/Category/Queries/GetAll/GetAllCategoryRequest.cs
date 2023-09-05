using Application.Dtos.Category;
using MediatR;

namespace Application.Features.Category.Queries.GetAll;

public class GetAllCategoryRequest : IRequest<IReadOnlyList<CategoryResponseDto>>
{

}