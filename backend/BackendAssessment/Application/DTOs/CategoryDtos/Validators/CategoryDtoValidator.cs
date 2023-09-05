using BackendAssessment.Application.DTOs.ProductDtos;
using FluentValidation;

namespace BackendAssessment.Application.DTOs.CategoryDtos.Validators;

public class CategoryDtoValidator : AbstractValidator<CategoryDto>
{
    public CategoryDtoValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull();      
    }
}