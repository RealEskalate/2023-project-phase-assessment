using Application.Contracts;
using FluentValidation;

namespace Application.Features.Product.Queries.GetSingleProduct;

public class GetSingleProductValidator : AbstractValidator<GetSingleProductCommand>
{
    public GetSingleProductValidator(IProductRepository productRepository)
    {
        RuleFor(p => p.ProductId)
            .NotNull().WithMessage("ProductId must NOT be null.")
            .MustAsync(async (productId, cancellationToken) =>
            {
                var productExists = await productRepository.Exists(productId);

                return productExists;
            })
            .WithMessage("{PropertyName} does not exist.");
    }
}