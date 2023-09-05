using Application.Contracts;
using Application.Features.Category.Commands.CreateCategory;
using FluentValidation;

namespace Application.Features.Category.Commands.UpdateCategory;

public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryValidator(ICategoryRepository categoryRepository)
    {
        RuleFor(c => c.CategoryReqResDto.Name)
            .NotEmpty().WithMessage("Name must NOT be empty.")
            .NotNull().WithMessage("Name must NOT be null.");
        
        RuleFor(c => c.CategoryReqResDto.Description)
            .NotEmpty().WithMessage("Description must NOT be empty.")
            .NotNull().WithMessage("Description must NOT be null.");
        
        RuleFor(c => c.CategoryId)
            .NotNull().WithMessage("CategoryId must NOT be null.")
            .MustAsync(async (Guid categoryId, CancellationToken cancellationToken) =>
            {
                var categoryExists = await categoryRepository.Exists(categoryId);
                return categoryExists;
            }).WithMessage("Category doesn't exist.");
    }
}