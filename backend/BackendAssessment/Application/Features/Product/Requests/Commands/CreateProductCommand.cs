using Application.Dtos;
using MediatR;

namespace Application.Features.Prodcut.Requests.Commands;

public class CreateProductCommand : IRequest<int>
{
    public required CreateProductDto CreateProductDto { get; set; }
}