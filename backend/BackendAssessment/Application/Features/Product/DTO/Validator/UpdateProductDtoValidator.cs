using BackendAssessment.Application.Contracts.Persistence;
using FluentValidation;

namespace BackendAssessment.Application.Features.Product.DTO.Validator;

public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
{
    private IUnitOfWork _unitOfWork;
    public UpdateProductDtoValidator(IUnitOfWork UnitOfWork)
    {
        _unitOfWork = UnitOfWork;
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required")
            .NotNull()
            .WithMessage("Id is required")
            .GreaterThan(0)
            .WithMessage("Id must be greater than 0")
            .MustAsync(
                async (id, token) =>
                {
                    var productExists = await _unitOfWork.ProductRepository.GetAsync(id);
                    return productExists != null;
                }
            )
            .WithMessage("{PropertyName} doesn't exist");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required")
            .NotNull()
            .WithMessage("Name is required")
            .MaximumLength(50)
            .WithMessage("Name must be less than 50 characters");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description is required")
            .NotNull()
            .WithMessage("Description is required")
            .MaximumLength(200)
            .WithMessage("Description length shouldn't exceed 200 characters");

        RuleFor(x => x.Price)
            .NotEmpty()
            .WithMessage("Price is required")
            .NotNull()
            .WithMessage("Price is required")
            .GreaterThan(0)
            .WithMessage("Price must be greater than 0");
        
       
    }
}