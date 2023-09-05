using Application.DTO.BookingDTO.DTO;
using FluentValidation;


namespace Application.DTO.BookingDTO.validations
{
    public class CommonBookingValidation : AbstractValidator<IBaseBookingDTO>
    {
        public CommonBookingValidation()
        {
            // RuleFor(x => x.Name)
            //     .NotEmpty().WithMessage("Name is required")
            //     .NotNull().WithMessage("Name is required")
            //     .MinimumLength(1).WithMessage("Name must be greater than 1 characters");

            // RuleFor(x => x.Description)
            //     .NotEmpty().WithMessage("Description is required")
            //     .NotNull().WithMessage("Description is required")
            //     .MinimumLength(1).WithMessage("Description must be greater than 1 characters");
        }
    }
}
