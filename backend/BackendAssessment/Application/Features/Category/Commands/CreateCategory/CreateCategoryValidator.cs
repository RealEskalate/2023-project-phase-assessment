using Application.DTOs.Category;
using FluentValidation;

namespace Application.Features.Category.Commands.CreateCategory;

public class CreateCategoryValidator : AbstractValidator<CategoryReqResDto>
{
    public CreateCategoryValidator()
    {
        RuleFor(c => c.Name)
            .NotNull().WithMessage("Name must NOT be null.")
            .NotEmpty().WithMessage("Name must NOT be empty.")
            .MaximumLength(50).WithMessage("Name must NOT exceed 50 characters.");
        RuleFor(c => c.Description)
            .NotNull().WithMessage("Description must NOT be null.")
            .NotEmpty().WithMessage("Description must NOT be empty.")
            .MaximumLength(500).WithMessage("Description must NOT exceed 500 characters.");
    }
}