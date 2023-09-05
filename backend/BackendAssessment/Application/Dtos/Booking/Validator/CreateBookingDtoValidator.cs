using Application.Contracts;
using Application.Dtos.Booking;
using FluentValidation;

namespace Application.Dtos.Category.Valiation;

public class CreateBookingDtoValidator : AbstractValidator<CreateBookingDto>{

    private readonly IUserRepository _userRepository;
    private readonly IProductRepository _productRepository;
    
    public CreateBookingDtoValidator(IUserRepository userRepository, IProductRepository productRepository)
    {
        _userRepository = userRepository;
        _productRepository = productRepository;

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.")
            .MustAsync(async (userId, cancellation) => {
                var user = await _userRepository.GetByIdAsync(userId);
                return user != null;
            }).WithMessage("{PropertyName} does not exist.");

        RuleFor(x => x.ProductId)
            .MustAsync(async (productId, cancellation) => {
                var user = await _productRepository.GetByIdAsync(productId);
                return user != null;
            });

        RuleFor(x => x.ReturnDate)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .GreaterThan(x => x.BookingDate).WithMessage("{PropertyName} must be greater than BookingDate.");
    }
}