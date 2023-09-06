using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Product.Validator
{
    public class CreateProductDtoValidator : AbstractValidator<CreateProductDTO>
    {
        public CreateProductDtoValidator()
        {
            RuleFor(dto => dto.name)
                .NotEmpty()
                .WithMessage("name is required.");

            RuleFor(dto => dto.description)
                .NotEmpty()
                .WithMessage("Reciever description is required.");

            RuleFor(dto => dto.pricing)
                .NotEmpty()
                .WithMessage("price is required.");
        }

    }
}
