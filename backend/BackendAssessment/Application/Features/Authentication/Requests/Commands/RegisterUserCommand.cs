using MediatR;
using ProductHub.Application.Common.Responses;
using ProductHub.Application.DTOs.Authentication;

namespace ProductHub.Application.Features.Authentication.Requests.Commands;

public class RegisterUserCommand : IRequest<CommonResponse<LoggedInUserDto>>
{
    public RegisterUserDto RegisterUserDto { get; set; } = null!;
}
