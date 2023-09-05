using Application.Dtos.Common;

namespace Application.Dtos.ProductDto;

public interface IProductDto 
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Pricing { get; set; }
    public int Availability { get; set; }
}