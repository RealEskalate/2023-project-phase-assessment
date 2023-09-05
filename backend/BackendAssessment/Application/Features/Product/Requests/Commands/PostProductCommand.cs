using Backend.Application.DTOs.Product;
using ErrorOr;
using MediatR;

namespace Backend.Application.Features.Product;

public class PostProductCommand : IRequest<ErrorOr<ProductDto>>
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Image { get; set; } = null!;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string Category { get; set; } = null!;
    public string Brand { get; set; } = null!;
}