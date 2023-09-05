using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.User.Validator
{
    public class IUserValidator : AbstractValidator<IUserDto>
    {
        public IUserValidator() {
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .EmailAddress().WithMessage("{PropertyName} is invalid")
                .NotNull();

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MinimumLength(8).WithMessage("{PropertyName} must be 8 characters. ")
                .Matches("[A-z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches("[a-z]").WithMessage("Password must contain at least one small letter.")
                .Matches("[0-9]").WithMessage("Password must contain at least one number.")
                .Matches("[!@#$%^&*]").WithMessage("Password must contain at least one special character.");
        }
    }
}
