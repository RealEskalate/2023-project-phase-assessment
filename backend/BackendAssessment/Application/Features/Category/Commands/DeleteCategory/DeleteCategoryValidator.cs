using Application.Contracts;
using FluentValidation;

namespace Application.Features.Category.Commands.DeleteCategory;

public class DeleteCategoryValidator : AbstractValidator<DeleteCategoryCommand>
{
    public DeleteCategoryValidator(ICategoryRepository categoryRepository)
    {
        RuleFor(c => c.CategoryId)
            .NotNull().WithMessage("CategoryId must NOT be null.")
            .MustAsync(async (categoryId, cancellationToken) =>
            {
                var categoryExists = await categoryRepository.Exists(categoryId);

                return categoryExists;
            })
            .WithMessage("{PropertyName} does not exist.");
    }
}