using Application.DTOs.User;
using FluentValidation;

namespace Application.DTOs.Users.Validations
{
    public class IValidateUserDto: AbstractValidator<IUserDto>
    {
        public IValidateUserDto()
        {
          RuleFor(User => User.UserName)
          .NotEmpty().WithMessage("{PropertyName} is required")
          .NotNull()
          .MaximumLength(50).WithMessage("{PropertyName} length should be less than 50 characters");


         
        }

    }
}