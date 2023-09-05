using Application.Contracts.Persistence;
using FluentValidation;

namespace Application.Dtos.CategoryDtos.Validator;

public class UpdateCategoryDtoValidator : AbstractValidator<UpdateCategoryDto>
{
    public UpdateCategoryDtoValidator(ICategoryRepository categoryRepository)
    {
        Include(new ICategoryDtoValidator());
        
        RuleFor(dto => dto.Id)
            .NotEmpty()
            .WithMessage("Id is required.")
            .MustAsync(async (id, token) => await categoryRepository.Exists(id))
            .WithMessage("Category does not exist.");
             
            
        
    }
}