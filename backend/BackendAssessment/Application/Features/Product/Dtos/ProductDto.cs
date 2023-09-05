using Application.Features.Category.Dtos;

namespace Application.Features.Product.Dtos;

public class ProductDto
{
    public string Name { get; set; } = null!;
    public int Price { get; set; }
    public int Stock { get; set; }
    public int UserId { get; set; }
    public List<CategoryDto> Categories { get; set; } = null!;
}
