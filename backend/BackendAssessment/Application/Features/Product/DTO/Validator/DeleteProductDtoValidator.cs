using BackendAssessment.Application.Contracts.Persistence;
using FluentValidation;

namespace BackendAssessment.Application.Features.Product.DTO.Validator;

public class DeleteProductDtoValidator:  AbstractValidator<DeleteProductDto>
{
    private IUnitOfWork _unitOfWork;
    public DeleteProductDtoValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        RuleFor(x => x.Id)
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
            )
            .WithMessage("{PropertyName} doesn't exist");;
    }
}