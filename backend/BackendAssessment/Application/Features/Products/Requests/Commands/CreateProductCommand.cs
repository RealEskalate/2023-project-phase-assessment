using Application.DTOs.Product;
using Application.Responses;
using MediatR;
using Domain.Entities;

namespace Application.Features.Products.Requests.Commands;

public class CreateProductCommand : IRequest<BaseCommandResponse<Product>>
{
    public CreateProductDto ProductDto { get; set; } = null!;
}