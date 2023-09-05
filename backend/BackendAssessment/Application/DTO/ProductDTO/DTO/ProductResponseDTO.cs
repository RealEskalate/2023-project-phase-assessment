using Domain.Entites;

namespace Application.DTO.ProductDTO.DTO
{
    public class ProductResponseDTO : IBaseProductDTO
    {
        public string? Name {get; set;}
        public string? Description {get; set;}
        public decimal Price {get; set;}
        public bool IsInStock {get; set;}
    }
}
