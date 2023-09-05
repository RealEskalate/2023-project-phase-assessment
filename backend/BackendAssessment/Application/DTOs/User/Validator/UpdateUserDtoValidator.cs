
using Application.Contracts.Persistence;
using Application.DTOs.User;
using Application.DTOs.User.Validator;
using FluentValidation;

namespace Application.DTOs.User.Validator;

public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>{

    public UpdateUserDtoValidator(IUserRepository userRepository){
        Include(new UserDtoValidator( userRepository));

        RuleFor(user => user)
            .MustAsync(async (us, cancellation) => {
                var existingUser = await userRepository.Get(us.Id);
                return existingUser != null;
            })
            .WithMessage("User Does not exist")
            .MustAsync(async (us, cancellation) => {
                var existingUser = await userRepository.GetUserByEmail(us.Email);
                return existingUser == null || existingUser?.Id == us.Id;
            })
            .WithMessage("Email already exists")
            .MustAsync(async (us, cancellation) => {
                var existingUser = await userRepository.GetUserByUsername(us.Username);
                return existingUser == null && existingUser?.Id == us.Id;
            })
            .WithMessage("UserName already exists");
    }
    
}