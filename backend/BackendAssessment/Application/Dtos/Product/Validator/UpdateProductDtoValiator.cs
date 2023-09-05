using Application.Contracts;
using FluentValidation;

namespace Application.Dtos.Product.Valiation;

public class UpdateProductDtoValidator : AbstractValidator<UpdateCategoryDto>{
    private readonly ICategoryRepository _categoryRepository;
    public UpdateProductDtoValidator(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.")
            .MustAsync(async (id, cancellation) =>
            {
                var category = await _categoryRepository.GetByIdAsync(id);
                return category != null;
            }).WithMessage("Category does not exist.");
        
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