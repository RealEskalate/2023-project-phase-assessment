using Application.Dtos.Auth;
using MediatR;


namespace Application.Features.Auth.Requests.Commands;
public class LoginUserRequest : IRequest<string>
{
    public required LoginUserDto LoginUserDto{ get; set; }
}
