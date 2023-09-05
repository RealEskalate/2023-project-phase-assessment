using Application.Contracts.Persistence;
using FluentValidation;

namespace Application.Dtos.ProductDto.Validator;

public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
{

    public CreateProductDtoValidator(ICategoryRepository categoryRepository)
    {
        Include( new IProductDtoValidator());

        RuleFor(dto => dto.Categoryid)
            .NotEmpty()
            .WithMessage("Id is required.")
            .MustAsync(async (id, token) => await categoryRepository.Exists(id))
            .WithMessage("Category does not exist.");
            
    }
}