using Application.DTO.ProductDTO.DTO;
using FluentValidation;


namespace Application.DTO.ProductDTO.validations
{
    public class ProductCreateValidation : AbstractValidator<ProductCreateDTO>
    {
        public ProductCreateValidation()
        {
            Include(new CommonProductValidation());
        }
    }
}
