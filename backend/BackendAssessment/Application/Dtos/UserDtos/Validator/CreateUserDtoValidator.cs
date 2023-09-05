using Application.Contracts.Persistence;
using FluentValidation;

namespace Application.Dtos.UserDtos.Validator;

public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
{
    public CreateUserDtoValidator(IUserRepository userRepository)
    {
        RuleFor(user => user.Email)
            .EmailAddress()
            .WithMessage("Invalid Email");
        RuleFor(user => user.UserName)
            .NotEmpty()
            .WithMessage("Username Is Required")
            .Matches(@"^[a-zA-Z0-9_]+$")
            .WithMessage("Invalid Username Format");
        RuleFor(user => user.Email)
            .MustAsync(async (email, cancellation) =>
            {
                var existingUser = await userRepository.GetUserByEmail(email);
                return existingUser == null;
            })
            .WithMessage("Email already exists")
            .MustAsync(async (username, cancellation) =>
            {
                var existingUser = await userRepository.GetUserByUserName(username);
                return existingUser == null;
            })
            .WithMessage("Username already exists");
    }
}