using Application.DTOs.User;
using MediatR;

namespace Application.Features.User.Commands.ToggleUserRole;

public class ToggleUserRoleCommand : IRequest<UserResponseDto>
{
    public int UserId { get; set; }
}