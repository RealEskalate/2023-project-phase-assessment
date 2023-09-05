using Application.Contracts.Persistence;
using FluentValidation;

namespace Application.DTOs.Product.validators;

public class BaseProductDtoValidator : AbstractValidator<IProductDto>
{
    public BaseProductDtoValidator(IUnitOfWork unitOfWork)
    {
        RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage("Name is required");
        RuleFor(dto => dto.Description)
            .NotEmpty().WithMessage("Description is required");
        // RuleFor(dto => dto.CategoryId)
        //     .MustAsync(async (categoryId, token) => 
        //         await unitOfWork.CategoryRepository.Exists(categoryId))
        //     .WithMessage("Category does not exist");
    }
}