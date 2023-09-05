using FluentValidation;
using ProductHub.Application.Contracts.Persistence;

namespace ProductHub.Application.DTOs.CategoryDtos.Validators;

public class DeleteCategoryDtoValidator : AbstractValidator<DeleteCategoryDto>
{
    private readonly ICategoryRepository _categoryRepository;
    public DeleteCategoryDtoValidator(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;

        RuleFor(p => p.Id)
        .NotNull().WithMessage("Category id cannot be null.")
        .MustAsync(async (id, token) =>
        {
            return await _categoryRepository.ExistsAsync(id);

        }).WithMessage("Category doesnot exist.");
    }
}