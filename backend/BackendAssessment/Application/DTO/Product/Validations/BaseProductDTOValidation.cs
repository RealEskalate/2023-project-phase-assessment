using Application.DTO.Product.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Product.Validations
{
    public class BaseProductDTOValidation : AbstractValidator<IBaseProductDTO>
    {
        public BaseProductDTOValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .MaximumLength(100)
                .WithMessage("Name can't be longer than 50 characters");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Description is required")
                .MaximumLength(500)
                .WithMessage("Description can't be longer than 200 characters");

            RuleFor(x => x.Price)
                .NotEmpty()
                .WithMessage("Price is required")
                .GreaterThan(0)
                .WithMessage("Price must be greater than 0");

            RuleFor(x => x.Quantity)
                .NotEmpty()
                .WithMessage("Quantity is required")
                .GreaterThan(0)
                .WithMessage("Quantity must be greater than 0");    



            
            
        }
    }
}
