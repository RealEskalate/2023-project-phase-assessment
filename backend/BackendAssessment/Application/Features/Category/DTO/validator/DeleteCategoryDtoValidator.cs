using BackendAssessment.Application.Contracts.Persistence;
using FluentValidation;
using FluentValidation.Validators;

namespace BackendAssessment.Application.Features.Category.DTO.validator;

public class DeleteCategoryDtoValidator: AbstractValidator<DeleteCategoryDto>
{
    private IUnitOfWork _unitOfWork;
    public DeleteCategoryDtoValidator(IUnitOfWork unitOfWork)
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
    }
}