using Application.Dto.Category;
using MediatR;

namespace Application.Features.Category.Requests.Queries;

public record GetCategoriesRequest() : IRequest<IReadOnlyList<CategoryDto>>;