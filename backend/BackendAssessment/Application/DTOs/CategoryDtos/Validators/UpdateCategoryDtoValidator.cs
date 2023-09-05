using FluentValidation;
using ProductHub.Application.Contracts.Persistence;
using ProductHub.Application.DTOs.CategoryDtos;


namespace ProductHub.Application.DTOs.CategoryDtos.Validators;


public class UpdateCategoryDtoValidator : AbstractValidator<UpdateCategoryDto>
{
    private readonly ICategoryRepository _categoryRepository;
    public UpdateCategoryDtoValidator(ICategoryRepository catgeoryRepository)
    {
        _categoryRepository = catgeoryRepository;

        RuleFor(p => p.Id)
        .NotNull().WithMessage("Category id cannot be null.")
        .MustAsync(async (id, token) =>
        {
            return await _categoryRepository.ExistsAsync(id);

        }).WithMessage("Category doesnot exist.");

        RuleFor(p => p.Name)
        .NotNull().WithMessage("Category name cannot be null.")
        .NotEmpty().WithMessage("Category name cannot be empty.")
        .MaximumLength(100).WithMessage("Category name cannot have more than 100 characters.");

        RuleFor(p => p.Description)
        .NotNull().WithMessage("Category description cannot be null.")
        .NotEmpty().WithMessage("Category description cannot be empty.")
        .MaximumLength(1000).WithMessage("Category description cannot have more than 1000 characters.");
    }
}
