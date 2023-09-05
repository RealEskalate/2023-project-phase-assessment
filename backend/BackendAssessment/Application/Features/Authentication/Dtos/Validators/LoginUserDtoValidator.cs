using FluentValidation;

namespace Application.Features.Authentication.Dtos.Validators;

public class LoginUserDtoValidator : AbstractValidator<LoginUserDto>
{
    public LoginUserDtoValidator()
    {
        Include(new UserDtoValidator());
    }
}
