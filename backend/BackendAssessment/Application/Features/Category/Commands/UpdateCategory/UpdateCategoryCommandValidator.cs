using Application.Contracts;
using FluentValidation;

namespace Application.Features.Category.Commands.UpdateCategory;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator( ICategoryRepository categoryRepository)
    {
        RuleFor(p => p.CategoryDto.Name)
            .Null()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

        RuleFor(p => p.CategoryDto.Description)
            .Null()
            .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
        
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