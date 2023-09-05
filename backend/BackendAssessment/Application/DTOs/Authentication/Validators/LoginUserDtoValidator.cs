using FluentValidation;

namespace ProductHub.Application.DTOs.Authentication.Validators;
public class LoginUserDtoValidator : AbstractValidator<LoginUserDto>
{
    public LoginUserDtoValidator()
    {
        Include(new UserDtoValidator());
    }
}
