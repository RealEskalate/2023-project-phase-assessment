using Application.Contracts.Persistence;
using FluentValidation;

namespace Application.DTOs.Category.validators;

public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
{
    public CreateCategoryDtoValidator(IUnitOfWork unitOfWork)
    {
        Include(new BaseCategoryDtoValidator(unitOfWork));
    }
}