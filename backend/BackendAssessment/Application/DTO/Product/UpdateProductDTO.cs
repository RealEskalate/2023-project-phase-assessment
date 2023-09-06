using Application.DTO.Common;

namespace Application.DTO.Product
{
    public class UpdateProductDTO : BaseDTO
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public double Pricing { get; set; }
        public bool Availability { get; set; }
    }
}