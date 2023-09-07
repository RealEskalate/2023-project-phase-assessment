using BackendAssessment.Application.Contracts.Persistence;
using FluentValidation;

namespace BackendAssessment.Application.Features.Product.DTO.Validator;

public class AcquireProductDtoValidator: AbstractValidator<AcquireProductDto>
{
    private IUnitOfWork _unitOfWork;
    public AcquireProductDtoValidator(
        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        RuleFor(x => x.ProductId)
            .NotEmpty()
            .WithMessage("Id is required")
            .NotNull()
            .WithMessage("Id is required")
            .MustAsync(
                async (id, token) =>
                {
                    var productExists = await _unitOfWork.ProductRepository.GetAsync(id);
                    return productExists != null;
                }
                );
        
        RuleFor(x => x.Available)
            .NotEmpty()
            .WithMessage("Quantity is required")
            .NotNull()
            .WithMessage("Quantity is required")
            .GreaterThan(0)
            .WithMessage("Quantity must be greater than 0");
            
        RuleFor(x => x.CustomerId)
            .NotEmpty()
            .WithMessage("CustomerId is required")
            .NotNull()
            .WithMessage("CustomerId is required")
            .MustAsync(
                async (id, token) =>
                {
                    var userExists = await _unitOfWork.UserRepository.GetAsync(id);
                    return userExists != null;
                }
            );
        
    }
     
}