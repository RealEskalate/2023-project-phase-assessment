using BackendAssessment.Application.Contracts.Persistence;
using FluentValidation;

namespace BackendAssessment.Application.Features.Category.DTO.validator;

public class UpdateCategoryDtoValidator : AbstractValidator<UpdateCategoryDto>
{
     private IUnitOfWork _unitOfWork;
    public UpdateCategoryDtoValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required")
            .NotNull()
            .MustAsync(async (id, cancellation) =>
            {
                var foundCategory = await _unitOfWork.CategoryRepository.GetAsync(id);
                return foundCategory != null;
            }).WithMessage("Category not found");
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