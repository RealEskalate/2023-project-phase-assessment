using Application.Dtos.Common;

namespace Application.Dtos;

public class ProductDto : BaseDto
{
    public string Name { get; set; } = default!;

    public string Description { get; set; } = default!;

    public decimal Price { get; set; }

    public int CategoryId { get; set; }

    public CategoryDto? Category { get; set; }
}