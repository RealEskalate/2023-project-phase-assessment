using BackendAssessment.Application.DTOs.ProductDtos;
using FluentValidation;

namespace BackendAssessment.Application.DTOs.Products.Validators;

public class ProductDtoValidator : AbstractValidator<ProductDto>
{
    public ProductDtoValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters");
        RuleFor(dto => dto.Price)
            .GreaterThan(0).WithMessage("{PropertyName} is greater than zero.");
        RuleFor(dto => dto.Detail)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(2000).WithMessage("{PropertyName} must not exceed 2000 characters");
    
    }

    // internal Task ValidateAsync(ProductDto productDto, object token)
    // {
    //     throw new NotImplementedException();
    // }
}