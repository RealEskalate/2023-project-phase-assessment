using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using FluentValidation;

namespace Application.DTOs.Product.Validators
{
    public class IProductDtoValidator : AbstractValidator<IProductDto>
    {
        public IProductDtoValidator()
        {
            RuleFor(c => c.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(20).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
            RuleFor(c => c.Description)
           .NotEmpty().WithMessage("{PropertyName} is required.")
           .NotNull()
           .MaximumLength(300).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
            RuleFor(c => c.Pricing)
           .NotEmpty().WithMessage("{PropertyName} is required.")
           .NotNull();
            RuleFor(c => c.Availability)
           .NotEmpty().WithMessage("{PropertyName} is required.")
           .NotNull()
           .GreaterThan(0);

        }
    }
}