using FluentValidation;

namespace BackendAssessment.Application.Features.Product.DTO.Validator;

public class AcquireProductDtoValidator: AbstractValidator<AcquireProductDto>
{
    public AcquireProductDtoValidator()
    {
        RuleFor(x => x.ProductId)
            .NotEmpty()
            .WithMessage("Id is required")
            .NotNull()
            .WithMessage("Id is required");
        
        RuleFor(x => x.Available)
            .NotEmpty()
            .WithMessage("Quantity is required")
            .NotNull()
            .WithMessage("Quantity is required")
            .GreaterThan(0)
            .WithMessage("Quantity must be greater than 0");
            
        RuleFor(x => x.CustomerId)
            .NotEmpty()
            .WithMessage("CustomerId is required")
            .NotNull()
            .WithMessage("CustomerId is required");
        
    }
     
}