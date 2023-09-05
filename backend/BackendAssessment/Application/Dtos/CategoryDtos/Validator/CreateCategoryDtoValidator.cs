using FluentValidation;

namespace Application.Dtos.CategoryDtos.Validator;

public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
{
    public CreateCategoryDtoValidator()
    {
        Include(new ICategoryDtoValidator());
    }
}