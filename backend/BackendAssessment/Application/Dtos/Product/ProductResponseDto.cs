
using Application.Dtos.Common;

namespace Application.Dtos.Product;

public class ProductResponseDto : BaseDto
{
    public string Name { get; set;} = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public double Pricing { get; set; } = 0.0;
    public bool Availability { get; set; } = false;

}