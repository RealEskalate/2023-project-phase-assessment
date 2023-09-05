using FluentValidation;
using ProductHub.Application.Contracts.Persistence;

namespace ProductHub.Application.DTOs.ProductDtos.Validators;


public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
{
    private readonly IUserRepository _userRepository;
    private readonly ICategoryRepository _catgeoryRepository;
    private readonly IProductRepository _productRepository;
    public UpdateProductDtoValidator(IUserRepository userRepository, ICategoryRepository catgeoryRepository, IProductRepository productRepository)
    {
        _userRepository = userRepository;
        _catgeoryRepository = catgeoryRepository;
        _productRepository = productRepository;

        RuleFor(p => p.Name)
        .NotNull().WithMessage("Product name cannot be null.")
        .NotEmpty().WithMessage("Product name cannot be empty.")
        .MaximumLength(100).WithMessage("Product name cannot have more than 100 characters.");

        RuleFor(p => p.Description)
        .NotNull().WithMessage("Product description cannot be null.")
        .NotEmpty().WithMessage("Product description cannot be empty.")
        .MaximumLength(1000).WithMessage("Product description cannot have more than 1000 characters.");

        RuleFor(p => p.ActorId)
        .NotNull().WithMessage("Product creator id cannot be null.")
        .MustAsync(async (id, token)=>{
            var user =  await _userRepository.GetAsync(id);
            return user != null;
        }).WithMessage("Product creator id doesnot match with any user id.");

        RuleFor(p => p.CategoryId)
        .NotNull().WithMessage("Product category id cannot be null.")
        .MustAsync(async (id, token)=>{
            var user =  await _catgeoryRepository.GetAsync(id);
            return user != null;
        }).WithMessage("Product category does not exist.");

        RuleFor(p => p.Pricing)
        .NotNull().WithMessage("Product price cannot be null.")
        .GreaterThan(0).WithMessage("Product price must be greater than zero.");

        RuleFor(p => new { p.Id, p.ActorId })
        .NotNull().WithMessage("product creator id cannot be null.")
        .MustAsync(async (dto, token) =>
        {
            var product = await _productRepository.GetAsync(dto.Id);
            var user = await _userRepository.GetAsync(dto.ActorId);

            return user != null && product != null && product.CreatorId == user.Id;

        }).WithMessage("product creator id does not match with the id of creator of the product being deleted.");
    }
}