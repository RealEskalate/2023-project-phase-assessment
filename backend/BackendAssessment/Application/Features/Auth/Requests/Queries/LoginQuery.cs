using ErrorOr;
using Application.Services.Authentication;
using MediatR;

namespace Application.Features.Auth.Requests.Queries;

public record LoginQuery
(
    string? UserName = "",
    string? Email = "",
    string Password = ""
) : IRequest<ErrorOr<AuthenticationResult>>;