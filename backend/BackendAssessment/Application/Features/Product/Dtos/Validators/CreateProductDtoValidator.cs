using FluentValidation;

namespace Application.Features.Product.Dtos.Validators;

public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
{
    public CreateProductDtoValidator()
    {
        Include(new ProductDtoValidator());
        RuleFor(p => p.UserId)
            .NotNull()
            .WithMessage("{PropertyName} is required.")
            .GreaterThan(0)
            .WithMessage("{PropertyName} must be greater than 0.");
    }
}
