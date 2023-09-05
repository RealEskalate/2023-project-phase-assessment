using MediatR;

namespace Application.Features.Product.Requests.Command;

public record DeleteProductRequest(int ProductId) : IRequest<Unit>;