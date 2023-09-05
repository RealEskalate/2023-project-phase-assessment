using MediatR;

namespace Application.Features.Category.Requests.Commands;

public record DeleteCategoryRequest(int Id) : IRequest<Unit>;