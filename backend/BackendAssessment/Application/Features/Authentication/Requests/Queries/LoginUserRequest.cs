

using MediatR;
using ProductHub.Application.Common.Responses;
using ProductHub.Application.DTOs.Authentication;

namespace ProductHub.Application.Features.Authentication.Requests.Queries;

public class LoginUserRequest : IRequest<CommonResponse<LoggedInUserDto>>
{
    public LoginUserDto LoginUserDto { get; set; } = null!;
}