using FluentValidation;
using ProductHub.Application.Contracts.Persistence;

namespace ProductHub.Application.DTOs.ProductDtos.Validators;

public class DeleteProductDtoValidator : AbstractValidator<DeleteProductDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IProductRepository _productRepository;
    public DeleteProductDtoValidator(IUserRepository userRepository, IProductRepository productRepository)
    {
        _userRepository = userRepository;
        _productRepository = productRepository;

        RuleFor(p => p.Id)
        .MustAsync(async (id, token) =>
        {
            bool productExists = await _productRepository.ExistsAsync(id);
            return productExists;
        }).WithMessage("Given id did not match any product id.");

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