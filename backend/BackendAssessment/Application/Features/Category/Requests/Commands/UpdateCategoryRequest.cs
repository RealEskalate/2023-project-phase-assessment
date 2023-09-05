using Application.Dto.Category;
using MediatR;

namespace Application.Features.Category.Requests.Commands;

public record UpdateCategoryRequest(CategoryDto CategoryDto) : IRequest<Unit>;