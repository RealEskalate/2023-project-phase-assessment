using Application.Contracts.Persistence;
using FluentValidation;

namespace Application.DTOs.User.Validator;

public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>{

    public CreateUserDtoValidator(IUserRepository userRepository){
        Include(new UserDtoValidator( userRepository));
        
        RuleFor(user => user.Email)
            .MustAsync(async (email, cancellation) =>
            {
                var existingUser = await userRepository.GetUserByEmail(email);
                return existingUser == null;
            })
            .WithMessage("Email already exists")
            .MustAsync(async (username, cancellation) =>
            {
                var existingUser = await userRepository.GetUserByUsername(username);
                return existingUser == null;
            })
            .WithMessage("Username already exists");
    }
    
}