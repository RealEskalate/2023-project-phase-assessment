using Application.Contracts;
using FluentValidation;

namespace Application.Features.User.Commands.DeleteUser;

public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator(IUserRepository userRepository)
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