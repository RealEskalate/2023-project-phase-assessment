using Application.Contracts.Persistence;
using FluentValidation;

namespace Application.Features.Products.Dtos.Validators;

public class ProductDtoValidator : AbstractValidator<ProductDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductDtoValidator(IUnitOfWork unitOfWork)
    {
        Include(new IProductDtoValidator());
        _unitOfWork = unitOfWork;

        RuleFor(p => p.UserId)
            .NotNull()
            .WithMessage("{PropertyName} is required.")
            .MustAsync(
                async (id, token) =>
                {
                    return await _unitOfWork.UserRepository.ExistsAsync(id);
                }
            )
            .WithMessage("{PropertyName} must be an existing user.");
    }
}
