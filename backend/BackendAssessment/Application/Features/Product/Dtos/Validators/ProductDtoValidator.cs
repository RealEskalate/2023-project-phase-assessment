using FluentValidation;

namespace Application.Features.Product.Dtos.Validators;

public class ProductDtoValidator : AbstractValidator<IProductDto>
{
    public ProductDtoValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .MaximumLength(20)
            .WithMessage("{PropertyName} must not exceed 20 characters.")
            .MinimumLength(3)
            .WithMessage("{PropertyName} must be at least 3 characters.");

        RuleFor(p => p.Price)
            .NotNull()
            .WithMessage("{PropertyName} is required.")
            .GreaterThan(0)
            .WithMessage("{PropertyName} must be greater than 0.");

        RuleFor(p => p.Stock)
            .NotNull()
            .WithMessage("{PropertyName} is required.")
            .GreaterThan(0)
            .WithMessage("{PropertyName} must be greater than 0.");

        // RuleFor(p => p.UserId)
        //     .NotNull()
        //     .WithMessage("{PropertyName} is required.")
        //     .GreaterThan(0)
        //     .WithMessage("{PropertyName} must be greater than 0.");

        RuleFor(p => p.Categories)
            .NotNull()
            .WithMessage("{PropertyName} is required.")
            .Must(c => c.Count > 0)
            .WithMessage("{PropertyName} must have at least one category.")
            .Must(c => c.Count <= 3)
            .WithMessage("{PropertyName} must have at most three categories.")
            .ChildRules(c =>
            {
                c.RuleFor(c => c.Count);
            });
    }
}
