using Application.Contracts.Persistance;

namespace Application.DTO.UserDTO.Validator;

using Application.Contracts.Persistance;
using FluentValidation;

public class IUserDtoValidator : AbstractValidator<IUserDto>
{

    public IUserDtoValidator(IUserRepository userRepository)
    {
        RuleFor(user => user.Email)
            .EmailAddress()
            .WithMessage("Invalid Email");
        RuleFor(user => user.UserName)
            .NotEmpty()
            .WithMessage("Username Is Required")
            .Matches(@"^[a-zA-Z0-9_]+$")
            .WithMessage("Invalid Username Format");
    }

}


