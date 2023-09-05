using ErrorOr;
using Backend.Application.Services.Authentication;
using MediatR;

namespace Backend.Application.Features.Auth.Requests.Queries;

public record LoginQuery
(
    string? UserName = "",
    string? Email = "",
    string Password = ""
) : IRequest<ErrorOr<AuthenticationResult>>;