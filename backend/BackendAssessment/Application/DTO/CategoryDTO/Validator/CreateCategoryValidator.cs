using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.CategoryDTO.Validator
{
    public class CreateCategoryValidator : AbstractValidator<CategoryDto>
    {
        public CreateCategoryValidator()
        {
            RuleFor(category => category.Name)
                .NotEmpty().WithMessage("Category name is required.")
                .MaximumLength(255).WithMessage("Category name cannot exceed 255 characters.");

            RuleFor(category => category.Description)
                .MaximumLength(1000).WithMessage("Description cannot exceed 1000 characters.");
        }
    }

}
