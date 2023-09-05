using Application.Dtos.Auth;
using MediatR;

namespace Application.Features.Auth.Requests.Commands
{
    public class RegisterUserCommand : IRequest<string>
    {
        public required  RegisterUserDto RegisterUserDto{ get; set; }
    }
}