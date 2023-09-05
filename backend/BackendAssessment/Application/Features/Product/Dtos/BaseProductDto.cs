using Application.Common.Dtos;
using Application.Features.Category.Dtos;

namespace Application.Features.Product.Dtos;

public class BaseProductDto : BaseDto
{
    public string Name { get; set; } = null!;
    public int Price { get; set; }
    public int Stock { get; set; }
    public List<CategoryDto> Categories { get; set; } = null!;
}
