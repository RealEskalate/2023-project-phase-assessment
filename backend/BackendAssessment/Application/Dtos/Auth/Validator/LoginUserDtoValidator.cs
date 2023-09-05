using FluentValidation;

namespace Application.Dtos.Auth.Valiation;

public class LoginUserDtoValidator : AbstractValidator<LoginUserDto>{
    public LoginUserDtoValidator()
    {

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
    }
}