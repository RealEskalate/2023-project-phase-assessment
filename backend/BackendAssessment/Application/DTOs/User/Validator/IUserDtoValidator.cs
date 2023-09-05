using Application.Contracts.Persistence;


namespace Application.DTOs.User.Validator;

using FluentValidation;

public class UserDtoValidator : AbstractValidator<IUserDto>{

    public UserDtoValidator(IUserRepository userRepository){
        
        RuleFor(user => user.Email)
            .EmailAddress()
            .WithMessage("Invalid Email");
        RuleFor(user => user.Username)
            .NotEmpty()
            .WithMessage("Username Is Required")
            .Matches(@"^[a-zA-Z0-9_]+$")
            .WithMessage("Invalid Username Format");
    }
}


