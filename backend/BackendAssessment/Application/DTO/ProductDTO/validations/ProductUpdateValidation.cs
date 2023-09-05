using Application.DTO.ProductDTO.DTO;
using FluentValidation;

namespace Application.DTO.ProductDTO.validations
{
    public class ProductUpdateValidation : AbstractValidator<ProductUpdateDTO> 
    {
        public ProductUpdateValidation()
        {
            Include(new CommonProductValidation());
        }
    }
}
