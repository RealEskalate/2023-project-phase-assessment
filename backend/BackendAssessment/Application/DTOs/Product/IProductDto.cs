using Application.Features.Categories.Dtos;

namespace Application.Features.Products.Dtos;

public interface IProductDto
{
    public string Name { get; set; }
    public int Price { get; set; }
    public int Quantity { get; set; }
    public List<CategoryDto> Categories { get; set; }
}
