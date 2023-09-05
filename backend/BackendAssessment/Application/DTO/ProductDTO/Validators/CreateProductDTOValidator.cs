using Application.Contracts.Persistance;
using FluentValidation;

namespace Application.DTO.ProductDTO.Validators;

public class CreateProductDTOValidator : AbstractValidator<CreateProductDTO>{
    public CreateProductDTOValidator(IProductRepository productRepository, ICategoryRepository categoryRepository){
        
        Include(new IProductDTOValidator(productRepository, categoryRepository));
        

    }
    
}