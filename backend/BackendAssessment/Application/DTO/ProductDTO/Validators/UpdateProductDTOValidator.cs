using Application.Contracts.Identity;
using Application.Contracts.Persistance;
using FluentValidation;

namespace Application.DTO.ProductDTO.Validators;

public class UpdateProductDTOValidator : AbstractValidator<UpdateProductDTO>{
    
    public UpdateProductDTOValidator(IProductRepository productRepository, ICategoryRepository categoryRepository, IAuthService authService){
        
        Include(new IProductDTOValidator(productRepository, categoryRepository));
        
        RuleFor(product => product.Id)
            .MustAsync(async (id, cancellation) => {
                var exist = await productRepository.Exists(id);
                return exist;
            })
            .WithMessage("Product not found");
        
        RuleFor(product => product)
            .MustAsync(async (updatedProduct, cancellation) =>
            {
                var product = await productRepository.Get(updatedProduct.Id);
                var role = await authService.GetUserRole(updatedProduct.UserId);
                return product.UserId == updatedProduct.UserId || role == "ADMIN";
            })
            .WithMessage("You are not allowed to do this operation");
    }
    
}

