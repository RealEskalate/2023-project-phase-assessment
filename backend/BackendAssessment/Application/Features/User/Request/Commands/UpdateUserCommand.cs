using Application.DTOs.User;
using Application.Responses;
using MediatR;

namespace Application.Features.User.Request.Commands;

public class UpdateUserCommand : IRequest<BaseCommandResponse<Unit?>>
{
    public required UpdateUserDto UpdateUser { get; set; }
}