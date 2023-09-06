using Application.DTO.Common;

namespace Application.DTO.Product
{
    public class CreateProductDTO : BaseDTO
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public double Pricing { get; set; }
        public bool Availability { get; set; }
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
    }
}