
using Application.Dtos.Product;
using FluentValidation;

namespace Application.Features.Product.Commands.Update;

public class UpdateProductValidator : AbstractValidator<ProductRequestDto>
{
    public UpdateProductValidator(){
       RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(20).WithMessage("Name cannot exceed 20 characters.");

        RuleFor(dto => dto.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(100).WithMessage("Description cannot exceed 100 characters.");

        RuleFor(dto => dto.Category)
            .NotEmpty().WithMessage("Category is required.")
            .MaximumLength(50).WithMessage("Category cannot exceed 50 characters.");

        RuleFor(dto => dto.Pricing)
            .NotNull().WithMessage("Pricing is required.")
            .InclusiveBetween(0, 1000).WithMessage("Pricing must be between 0 and 1000.");

        RuleFor(dto => dto.Availability)
            .NotNull().WithMessage("Availability is required.");
    }
}