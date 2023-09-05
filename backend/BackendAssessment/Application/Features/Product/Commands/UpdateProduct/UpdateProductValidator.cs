using Application.Contracts;
using FluentValidation;

namespace Application.Features.Product.Commands.UpdateProduct;

public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductValidator(IProductRepository productRepository)
    {
        RuleFor(p => p.ProductId)
            .NotNull().WithMessage("ProductId must NOT be null.")
            .MustAsync(async (Guid productId, CancellationToken cancellationToken) =>
            {
                var productExists = await productRepository.Exists(productId);
                return productExists;
            }).WithMessage("Product doesn't exist.");
    }
}