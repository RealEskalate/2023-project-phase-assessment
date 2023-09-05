using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.ProductDTO.Validator
{
    public class CreateProductDtoValidator : AbstractValidator<ProductDto>
    {
        public CreateProductDtoValidator()
        {
            RuleFor(product => product.Name)
                .NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(255).WithMessage("Product name cannot exceed 255 characters.");

            RuleFor(product => product.Description)
                .MaximumLength(1000).WithMessage("Description cannot exceed 1000 characters.");

            RuleFor(product => product.Pricing)
                .GreaterThanOrEqualTo(0).WithMessage("Pricing should be a non-negative value.");

            RuleFor(product => product.Availability)
                .GreaterThanOrEqualTo(0).WithMessage("Availability should be a non-negative value.");
        }
    }
}
