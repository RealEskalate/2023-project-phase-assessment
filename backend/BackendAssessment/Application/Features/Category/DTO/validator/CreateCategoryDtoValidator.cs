using BackendAssessment.Application.Contracts.Persistence;
using FluentValidation;

namespace BackendAssessment.Application.Features.Category.DTO.validator;

public class CreateCategoryDtoValidator: AbstractValidator<CreateCategoryDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCategoryDtoValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .NotNull()
            .MaximumLength(50).WithMessage("Name must not exceed 50 characters");
        
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required")
            .NotNull()
            .MaximumLength(50).WithMessage("Description must not exceed 50 characters");
            

    }

   
}