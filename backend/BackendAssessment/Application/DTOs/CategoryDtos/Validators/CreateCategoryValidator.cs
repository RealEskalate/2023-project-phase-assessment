using FluentValidation;
using ProductHub.Application.DTOs.CategoryDtos;

namespace ProductHub.Application.DTOs.CategorydDtos.Validators;


public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
{
    public CreateCategoryDtoValidator()
    {
        RuleFor(p => p.Name)
        .NotNull().WithMessage("Category name cannot be null.")
        .NotEmpty().WithMessage("Category name cannot be empty.")
        .MaximumLength(20).WithMessage("Category name cannot have more than 20 characters.");

        RuleFor(p => p.Description)
        .NotNull().WithMessage("Category description cannot be null.")
        .NotEmpty().WithMessage("Category description cannot be empty.")
        .MaximumLength(1000).WithMessage("Category description cannot have more than 1000 characters.");

    }
}