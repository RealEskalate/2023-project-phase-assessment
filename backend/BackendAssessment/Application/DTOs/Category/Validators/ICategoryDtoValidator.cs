using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using FluentValidation;

namespace Application.DTOs.Category.Validators
{
    public class ICategoryDtoValidator : AbstractValidator<ICategoryDto>
    {
        public ICategoryDtoValidator()
        {
            RuleFor(c => c.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(20).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
            RuleFor(c => c.Description)
           .NotEmpty().WithMessage("{PropertyName} is required.")
           .NotNull()
           .MaximumLength(300).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
           

        }
    }
}