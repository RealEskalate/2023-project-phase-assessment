using FluentValidation;

namespace BackendAssessment.Application.DTOs.Authentication.Validators;

public class LoginUserDtoValidator : AbstractValidator<LoginUserDto>
{
    public LoginUserDtoValidator()
    {
        Include(new UserDtoValidator());
    }
}
