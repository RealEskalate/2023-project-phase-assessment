using Application.Contracts;
using FluentValidation;

namespace Application.Dtos.Auth.Valiation;

public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>{

    private readonly IUserRepository _userRepository;
    public RegisterUserDtoValidator( IUserRepository userRepository)
    {
        _userRepository = userRepository;


        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .EmailAddress().WithMessage("{PropertyName} must be a valid email address.")
            .MustAsync(async (email, cancellation) =>
            {
                var user = await _userRepository.ExistsByEmailAsync(email);
                return user;
            }).WithMessage("User with this email already exists.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MinimumLength(6).WithMessage("{PropertyName} must be at least 6 characters.")
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

        RuleFor(x => x.ConfirmPassword)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .Equal(x => x.Password).WithMessage("{PropertyName} must match password.");
    }
}
