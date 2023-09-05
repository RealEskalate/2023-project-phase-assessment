using FluentValidation;

namespace Application.Features.Product.Dtos.Validators;

public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
{
    public UpdateProductDtoValidator()
    {
        Include(new ProductDtoValidator());
    }
}
