using Application.Contracts;
using FluentValidation;

namespace Application.Features.Product.Commands.UpdateProduct;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator(IProductRepository productRepository)
    {
        //Rule For Name
        RuleFor(p => p.ProductDto.Name)
            .Null()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
        
        //Rule For Description
        RuleFor(p => p.ProductDto.Description)
            .Null()
            .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
        
        //Rule For Price
        RuleFor(p => p.ProductDto.Pricing)
            .Null()
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");
        
        //Rule For Availability
        RuleFor(p => p.ProductDto.Availability)
            .Null();
        
        //Rule for ProductId
        RuleFor(x => x.ProductId)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MustAsync(async (id, token) =>
            {
                var userExists = await productRepository.Exists(id);
                return userExists;
            })
            .WithMessage("{PropertyName} does not exist");
    }
}