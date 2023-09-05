using Application.Contracts.Identity;
using Application.Contracts.Persistance;
using FluentValidation;

namespace Application.DTO.ProductDTO.Validators;

public class IProductDTOValidator : AbstractValidator<IProductDTO>{
    public IProductDTOValidator(IProductRepository productRepository,  ICategoryRepository categoryRepository){
        RuleFor(product => product.Name)
            .NotEmpty()
            .WithMessage("Name Is Required");

        RuleFor(product => product.Description)
            .NotEmpty()
            .WithMessage("Description Is Required");
      
        RuleFor(product => product.Availability)
            .GreaterThan(0)
            .WithMessage("Availability Must Be Greater Than 0");
        RuleFor(product => product.Pricing)
            .GreaterThan(0)
            .WithMessage("Pricing Must Be Greater Than 0");
        RuleFor(product => product.CategoryId)
            .MustAsync(async (id, cancellation) =>
            {
                var exist = await categoryRepository.Exists(id);
                return  exist;
            })
            .WithMessage("Category not found");
        
    }
    
}