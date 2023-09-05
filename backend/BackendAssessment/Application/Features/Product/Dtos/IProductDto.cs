using Application.Features.Category.Dtos;

namespace Application.Features.Product.Dtos;

public interface IProductDto
{
    public string Name { get; set; }
    public int Price { get; set; }
    public int Stock { get; set; }
    public List<CategoryDto> Categories { get; set; }
}
