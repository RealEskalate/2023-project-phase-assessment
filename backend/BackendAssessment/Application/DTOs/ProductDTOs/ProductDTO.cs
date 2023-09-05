
namespace Application.DTOs.ProductDTOs
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Pricing { get; set; }
        public int Availability { get; set; }
        public int UserId { get; set; }

    }
}