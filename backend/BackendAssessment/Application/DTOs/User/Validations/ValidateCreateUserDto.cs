using FluentValidation;
using Application.Persistence.Contracts;
using Application.DTOs.User;

namespace Application.DTOs.Users.Validations
{
    public class ValidateCreateUserDto : AbstractValidator<CreateUserDto>
    {
        private readonly IUserRepository _userRepository;

        public ValidateCreateUserDto(IUserRepository userRepository)
        {
          _userRepository = userRepository;
          Include(new IValidateUserDto());

          RuleFor(User => User.Email)
          .NotEmpty().WithMessage("{PropertyName} is required")
          .EmailAddress().WithMessage("{PropertyName} is invalid")
          .NotNull()
          .MaximumLength(50).WithMessage("{PropertyName} length should be less than 50 characters");

         RuleFor(User => User.Password)
          .NotEmpty().WithMessage("{PropertyName} is required")
          .MinimumLength(8).WithMessage("{PropertyName} must be 8 characters. ")
          .Matches("[A-z]").WithMessage("Password must contain at least one uppercase letter.")
          .Matches("[a-z]").WithMessage("Password must contain at least one small letter.")
          .Matches("[0-9]").WithMessage("Password must contain at least one number.")
          .Matches("[!@#$%^&*]").WithMessage("Password must contain at least one special character.");
        }


        
    }
}