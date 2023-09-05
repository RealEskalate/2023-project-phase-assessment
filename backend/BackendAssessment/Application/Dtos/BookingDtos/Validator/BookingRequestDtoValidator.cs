using System.Data;
using Application.Contracts.Persistence;
using Domain.Entites;
using FluentValidation;

namespace Application.Dtos.BookingDtos.Validator;

public class BookingRequestDtoValidator : AbstractValidator<BookingRequestDto>
{
    public BookingRequestDtoValidator( IProductRepository productRepository)
    {
        RuleFor(booking => booking.ProductId)
            .NotEmpty()
            .WithMessage("ProductId is required")
            .MustAsync(async (id, token) => await productRepository.Exists(id))
            .WithMessage("Product does not exist");
        
        RuleFor(booking => booking.Quantity)
            .NotEmpty()
            .WithMessage("Quantity is required")
            .GreaterThan(0)
            .WithMessage("Quantity must be greater than 0");
       RuleFor(booking => booking.StartDate)
              .NotEmpty()
              .WithMessage("StartDate is required")
              .GreaterThan(DateTime.Now)
              .WithMessage("StartDate must be greater than today");
       RuleFor(booking => booking.EndDate)
                .NotEmpty()
                .WithMessage("EndDate is required")
                .GreaterThan(DateTime.Now)
                .WithMessage("EndDate must be greater than today");
    }
}