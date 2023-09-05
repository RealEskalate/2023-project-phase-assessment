using Application.Common.Dtos;
using Application.Features.Categories.Dtos;

namespace Application.Features.Products.Dtos;

public class ProductDto : BaseDto, IProductDto
{
    public string Name { get; set; } = null!;
    public int Price { get; set; }
    public int Quantity { get; set; }
    public Guid UserId { get; set; }
    public List<CategoryDto> Categories { get; set; } = null!;
}
