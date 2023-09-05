using Application.DTO.CategoryDTO.DTO;
using FluentValidation;


namespace Application.DTO.CategoryDTO.validations
{
    public class CommonCategoryValidation : AbstractValidator<IBaseCategoryDTO>
    {
        public CommonCategoryValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .NotNull().WithMessage("Name is required")
                .MinimumLength(1).WithMessage("Name must be greater than 1 characters");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required")
                .NotNull().WithMessage("Description is required")
                .MinimumLength(1).WithMessage("Description must be greater than 1 characters");
        }
    }
}
