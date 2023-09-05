using MediatR;

namespace Application.Dto.Category;

public record CreateCategoryDto(string Name, string Description) : IRequest<CategoryDto>;