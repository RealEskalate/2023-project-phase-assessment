// using Application.DTOs.Authentication;
using FluentValidation;

namespace ProductHub.Application.DTOs.Authentication.Validators;

public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
{
    public RegisterUserDtoValidator()
    {
        Include(new UserDtoValidator());

        RuleFor(u => u.Email)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .EmailAddress()
            .WithMessage("{PropertyName} must be a valid email address.");
    }
}
