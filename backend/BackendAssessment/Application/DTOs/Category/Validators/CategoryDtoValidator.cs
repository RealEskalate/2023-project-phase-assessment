using FluentValidation;

namespace Application.Features.Categories.Dtos.Validators;

public class CategoryDtoValidator : AbstractValidator<CategoryDto>
{
    public CategoryDtoValidator()
    {
        RuleFor(c => c.Name).NotNull().WithMessage("{PropertyName} is required.");
    }
}
