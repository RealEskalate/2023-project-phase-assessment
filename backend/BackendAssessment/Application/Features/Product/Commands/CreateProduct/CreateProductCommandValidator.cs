using Application.Contracts;
using FluentValidation;

namespace Application.Features.Product.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator(ICategoryRepository categoryRepository)
    {
        //Rule For Name
        RuleFor(p => p.ProductDto.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
        
        //Rule For Description
        RuleFor(p => p.ProductDto.Description)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
        
        //Rule For Price
        RuleFor(p => p.ProductDto.Pricing)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");
        
        //Rule For Availability
        RuleFor(p => p.ProductDto.Availability)
            .NotNull().WithMessage("{PropertyName} is required.");
        
        //Rule for CategoryId
        RuleFor(x => x.CategoryId)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MustAsync(async (id, token) =>
            {
                var userExists = await categoryRepository.Exists(id);
                return userExists;
            })
            .WithMessage("{PropertyName} does not exist");
    }
}