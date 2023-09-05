using Application.Contracts;
using Application.Dtos.Booking;
using FluentValidation;

namespace Application.Features.Booking.Validations;

public class UpdateBookingDtoValidator : AbstractValidator<UpdateBookingDto>{
    public UpdateBookingDtoValidator(IUserRepository userRepository, IProductRepository productRepository){
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull();
        
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MustAsync(async (userId, cancellation) => await userRepository.GetByIdAsync(userId) != null)
            .WithMessage("User with id: {PropertyValue} does not exist.")
            .MustAsync(async (userId, cancellation) => await userRepository.GetByIdAsync(userId) != null)
            .WithMessage("User with id: {PropertyValue} does not exist.");
        
        RuleFor(x => x.ProductId)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MustAsync(async (productId, cancellation) => await productRepository.GetByIdAsync(productId) != null)
            .WithMessage("Product with id: {PropertyValue} does not exist.");
        
        RuleFor(x => x.BookingDate)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .GreaterThan(DateTime.Now)
            .WithMessage("{PropertyName} must be greater than today.");
    }
}