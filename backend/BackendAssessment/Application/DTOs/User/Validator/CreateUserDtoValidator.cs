using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.User.Validator
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator() {

            RuleFor(dto => dto.username)
                .NotEmpty()
                .WithMessage("name is required.");

            RuleFor(dto => dto.email)
                .NotEmpty()
                .WithMessage("email is required.");

            RuleFor(dto => dto.password)
                .NotEmpty()
                .WithMessage("password is required.");
        
        }
    }
}
