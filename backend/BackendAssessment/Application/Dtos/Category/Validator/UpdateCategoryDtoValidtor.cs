using Application.Contracts;
using FluentValidation;

namespace Application.Dtos.Category.Valiation;

public class UpdateCategoryDtoValidator : AbstractValidator<UpdateCategoryDto>
{
    
    private readonly ICategoryRepository _categoryRepository;

    public UpdateCategoryDtoValidator( ICategoryRepository categoryRepository)
    {

        _categoryRepository = categoryRepository;

        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("{PropertyName} is required.").MustAsync(async (id, cancellation) =>
            {
                var category = await _categoryRepository.GetByIdAsync(id);
                return category != null;
            }).WithMessage("Category does not exist.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
    }
}