
using Application.Dtos.Category;
using FluentValidation;

namespace Application.Features.Category.Commands.Update;

public class UpdateCategoryValidator : AbstractValidator<CategoryRequestDto>
{
    public UpdateCategoryValidator(){
        RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(20).WithMessage("Name cannot exceed 20 characters.");

        RuleFor(dto => dto.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(100).WithMessage("Description cannot exceed 100 characters.");

    }
}