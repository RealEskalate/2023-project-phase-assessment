using Application.DTOs.Product.validators;

namespace Application.DTOs.Product;

public class CreateProductDto : IProductDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Price { get; set; } 
    public int CategoryId { get; set; }
    public int UserId { get; set; }
    public int Quantity { get; set; }
}