using Application.Contracts;
using FluentValidation;

namespace Application.Features.Product.Commands.DeleteProduct;

public class DeleteProductValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductValidator(IProductRepository productRepository)
    {
        RuleFor(p => p.ProductId)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MustAsync(async (productId, cancellationToken) => await productRepository.Exists(productId))
            .WithMessage("Product doesn't exist.");
    }
}