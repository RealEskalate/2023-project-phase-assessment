using Application.Contracts;
using FluentValidation;

namespace Application.Features.Category.Commands.DeleteCategory;

public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
{
    public DeleteCategoryCommandValidator(ICategoryRepository categoryRepository)
    {
        //Rule for CategoryId
        RuleFor(x => x.CategoryId)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MustAsync(async (id, token) =>
            {
                var userExists = await categoryRepository.Exists(id);
                return userExists;
            })
            .WithMessage("{PropertyName} does not exist");
    }
}