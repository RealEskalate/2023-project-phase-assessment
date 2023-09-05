using Application.Contracts.Persistance;
using FluentValidation;

namespace Application.DTO.CategoryDTO.CategoryDTOValidator;

public class CategoryDTOValidator : AbstractValidator<CategoryDTO>{
    public CategoryDTOValidator(ICategoryRepository categoryRepository){
        RuleFor(category => category.Name)
            .NotEmpty()
            .WithMessage("Name Is Required");

        RuleFor(category => category.Description)
            .NotEmpty()
            .WithMessage("Description Is Required");
    }
}