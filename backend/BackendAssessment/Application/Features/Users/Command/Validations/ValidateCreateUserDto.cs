using FluentValidation;
using Application.Persistence.Contracts;
using Authentication.Command.DTO;
using Domain.Entites;
using Application.Contracts.persistence;
using Application.Dtos.User.Validator;

namespace Application.Authentication.Command.Validations;

public class ValidateCreateUserDto : AbstractValidator<User>
{
    public ValidateCreateUserDto()
    {

        RuleFor(u => u.Username)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MaximumLength(50).WithMessage("{PropertyName} length should be less than 50 characters");

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