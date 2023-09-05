using Application.Contracts.Persistence;
using FluentValidation;

namespace Application.DTOs.Product.validators;

public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
{
    public CreateProductDtoValidator(IUnitOfWork unitOfWork)
    {
        Include(new BaseProductDtoValidator(unitOfWork));
    }
}