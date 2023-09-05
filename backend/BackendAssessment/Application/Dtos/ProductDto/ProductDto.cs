using Application.Dtos.Common;
using Domain.Entites;

namespace Application.Dtos.ProductDto;

public class ProductDto : BaseDto, IProductDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Pricing { get; set; }
    public int Availability { get; set; }
    public int UserId { get; set; }
    public virtual User? User { get; set; }
    public int CatagoryId { get; set; }
    public virtual Category? Category { get; set; }
}