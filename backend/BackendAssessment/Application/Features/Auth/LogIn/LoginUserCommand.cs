using Application.DTOs.Auth;
using Application.DTOs.User;
using MediatR;

namespace Application.Features.Auth.LogIn;

public class LoginUserCommand : IRequest<string>
{
    public AuthRequest AuthRequest { get; set; } = null!;
}