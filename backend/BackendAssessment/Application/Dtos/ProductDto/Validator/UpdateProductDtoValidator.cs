using Application.Contracts.Persistence;
using FluentValidation;

namespace Application.Dtos.ProductDto.Validator;

public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
{
    public UpdateProductDtoValidator(IProductRepository productRepository)
    {
        Include(new IProductDtoValidator());
        
        RuleFor( dto => dto.Id)
            .NotEmpty()
            .WithMessage("Id is required.")
            .MustAsync(async (id, token) => await productRepository.Exists(id))
            .WithMessage("Product does not exist.");
       

             
           
        
    }
}