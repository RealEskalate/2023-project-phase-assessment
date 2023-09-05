using Application.Dto.Category;
using MediatR;

namespace Application.Features.Category.Requests.Commands;

public record CreateCategoryRequest(CreateCategoryDto CreateCategoryDto) : IRequest<CategoryDto>;