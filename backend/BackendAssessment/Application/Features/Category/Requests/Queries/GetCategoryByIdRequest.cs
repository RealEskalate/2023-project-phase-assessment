using Application.Dto.Category;
using MediatR;

namespace Application.Features.Category.Requests.Queries;

public record GetCategoryByIdRequest(int Id) : IRequest<CategoryDto?>;