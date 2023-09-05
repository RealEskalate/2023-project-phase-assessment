using Application.Features.Category.Dtos;

namespace Application.Features.Product.Dtos;

public class CreateProductDto : IProductDto
{
    public string Name { get; set; } = null!;
    public int Price { get; set; }
    public int Stock { get; set; }
    public List<CategoryDto> Categories { get; set; } = null!;
    public int UserId { get; set; }
}
