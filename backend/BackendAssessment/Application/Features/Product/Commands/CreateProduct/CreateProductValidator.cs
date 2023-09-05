using Application.Contracts;
using Application.DTOs.Product;
using FluentValidation;

namespace Application.Features.Product.Commands.CreateProduct;

public class CreateProductValidator : AbstractValidator<CreateProductDto>
{
    public CreateProductValidator(ICategoryRepository categoryRepository)
    {
        RuleFor(p => p.Name)
            .NotNull().WithMessage("Name must NOT be null.")
            .NotEmpty().WithMessage("Name must NOT be empty.")
            .MaximumLength(50).WithMessage("Name must NOT exceed 50 characters.");

        RuleFor(p => p.Description)
            .NotNull().WithMessage("Description must NOT be null.")
            .NotEmpty().WithMessage("Description must NOT be empty.")
            .MaximumLength(500).WithMessage("Description must NOT exceed 500 characters.");

        RuleFor(p => p.Pricing)
            .NotNull().WithMessage("Price must NOT be null.")
            .NotEmpty().WithMessage("Price must NOT be empty.")
            .GreaterThan(0).WithMessage("Price must be greater than 0.");

        RuleFor(p => p.CategoryId)
            .NotNull().WithMessage("CategoryId must NOT be null.")
            .NotEmpty().WithMessage("CategoryId must NOT be empty.")
            .MustAsync(async (Guid categoryId, CancellationToken cancellationToken) =>
            {
                var categoryExists = await categoryRepository.Exists(categoryId);

                return categoryExists;
            }).WithMessage("Category doesn't exist.");
    }
}