using Application.DTOs.Common;

namespace Application.DTOs.Products
{
    public class ProductResponseDto : BaseEntityDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
    }
}