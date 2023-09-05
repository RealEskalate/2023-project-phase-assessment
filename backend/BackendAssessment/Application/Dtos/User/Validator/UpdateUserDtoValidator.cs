using Application.Contracts;
using FluentValidation;

namespace Application.Dtos.User.Valiation;

public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>{

    private readonly IUserRepository _userRepository;
    public UpdateUserDtoValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("{PropertyName} is required.").MustAsync(async (id, cancellation) =>
            {
                var user = await _userRepository.ExistsAsync(id);
                return user;
            }).WithMessage("User does not exist.");
        
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .EmailAddress().WithMessage("{PropertyName} must be a valid email address.")
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
            .MustAsync(async (email, cancellation) =>
            {
                var user = await _userRepository.ExistsByEmailAsync(email);
                return user;
            }).WithMessage("User with this email already exists.");
        
        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
            .MustAsync(async (username, cancellation) =>
            {
                var user = await _userRepository.ExistsByUsernameAsync(username);
                return user;
            }).WithMessage("User with this username already exists.");
        
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MinimumLength(8).WithMessage("{PropertyName} must be at least 8 characters.")
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
    }
    

}
