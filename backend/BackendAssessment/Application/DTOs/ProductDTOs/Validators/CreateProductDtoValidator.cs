using FluentValidation;
using ProductHub.Application.Contracts.Persistence;

namespace ProductHub.Application.DTOs.ProductDtos.Validators;


public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
{
    private readonly IUserRepository _userRepository;
    private readonly ICategoryRepository _catgeoryRepository;
    public CreateProductDtoValidator(IUserRepository userRepository, ICategoryRepository catgeoryRepository)
    {
        _userRepository = userRepository;
        _catgeoryRepository = catgeoryRepository;

        RuleFor(p => p.Name)
        .NotNull().WithMessage("Product name cannot be null.")
        .NotEmpty().WithMessage("Product name cannot be empty.")
        .MaximumLength(100).WithMessage("Product name cannot have more than 100 characters.");

        RuleFor(p => p.Description)
        .NotNull().WithMessage("Product description cannot be null.")
        .NotEmpty().WithMessage("Product description cannot be empty.")
        .MaximumLength(1000).WithMessage("Product description cannot have more than 1000 characters.");

        RuleFor(p => p.CreatorId)
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
    }
}