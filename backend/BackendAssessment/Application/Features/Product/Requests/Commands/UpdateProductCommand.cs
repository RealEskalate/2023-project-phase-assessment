using Application.Dtos;
using MediatR;

namespace Application.Features.Prodcut.Requests.Commands;

public class UpdateProductCommand : IRequest<Unit>
{
    public required UpdateProductDto UpdateProductDto { get; set; }
}