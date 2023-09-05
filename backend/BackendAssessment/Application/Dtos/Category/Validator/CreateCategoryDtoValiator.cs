using FluentValidation;

namespace Application.Dtos.Category.Valiation;

public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>{
    public CreateCategoryDtoValidator()
    {

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