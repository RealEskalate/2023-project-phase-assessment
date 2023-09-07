using FluentValidation;
namespace BackendAssessment.Application.Features.Product.DTO.Validator;

public class CreateProductDtoValidator: AbstractValidator<CreateProductDto>
{
    
    public CreateProductDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required")
            .NotNull()
            .WithMessage("Name is required");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description is required")
            .NotNull()
            .WithMessage("Description is required");

        RuleFor(x => x.Price)
            .NotEmpty()
            .WithMessage("Price is required")
            .NotNull()
            .WithMessage("Price is required");
    }
}