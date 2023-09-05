
using Application.Dtos.Category;
using FluentValidation;

namespace Application.Features.Category.Commands.Create;

public class CreateCategoryValidator : AbstractValidator<CategoryRequestDto>
{
    public CreateCategoryValidator(){
        RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(20).WithMessage("Name cannot exceed 20 characters.");

        RuleFor(dto => dto.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(100).WithMessage("Description cannot exceed 100 characters.");

    }
}