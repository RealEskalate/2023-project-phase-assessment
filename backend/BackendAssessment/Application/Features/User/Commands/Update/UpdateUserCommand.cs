
using Application.Dtos.User;
using MediatR;

namespace Application.Features.User.Commands.Update;

public class UpdateUserCommand : IRequest<UserResponseDto>
{
    public Guid UserId { get; set; }
    public UserRequestDto UpdateUser { get; set; } = null!;
}