using Application.Contracts;
using FluentValidation;

namespace Application.Features.User.Commands.ToggleUserRole;

public class ToggleUserRoleCommandValidator : AbstractValidator<ToggleUserRoleCommand>
{
    public ToggleUserRoleCommandValidator(IUserRepository userRepository)
    {
        //Rule for UserID
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MustAsync(async (id, token) =>
            {
                var userExists = await userRepository.Exists(id);
                return userExists;
            })
            .WithMessage("{PropertyName} does not exist");
    }
}