using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Persisitence;
using FluentValidation;

namespace Application.DTOs.Product.Validators
{
    public class IProductDtoValidator : AbstractValidator<IProductDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        public IProductDtoValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(30).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(300).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            RuleFor(p => p.CatagoryId)
                .MustAsync(async (id, token) => {
                    var catagoryExists = await _unitOfWork.CatagoryRepository.Exists(id);
                    return catagoryExists;
                })
                .WithMessage("{ProperyName} does not exist.");

            RuleFor(p => p.Pricing)
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be greater than or equal to {ComparisonValue}");
            
            RuleFor(p => p.Quantity)
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be greater than or equal to {ComparisonValue}");
        }
    }
}