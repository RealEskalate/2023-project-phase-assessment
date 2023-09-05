using FluentValidation;

namespace Application.Features.Categories.Dtos.Validators;

public class UpsertCategoryDtoValidator : AbstractValidator<UpsertCategoryDto>
{
    public UpsertCategoryDtoValidator()
    {
        RuleFor(c => c.Name).NotNull().WithMessage("{PropertyName} is required.");
    }
}
