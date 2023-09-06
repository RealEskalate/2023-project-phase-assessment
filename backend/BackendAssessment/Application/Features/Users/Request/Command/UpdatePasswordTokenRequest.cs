using Application.DTOs.Users;
using ErrorOr;
using MediatR;

namespace Application.Features.Users.Request.Command
{
    public class UpdatePasswordTokenRequest : IRequest<ErrorOr<string>>
    {
        public string Token { get; set; } = null!;
        public UpdatePasswordTokenRequestDTO updatePasswordTokenRequestDTO { get; set; } = null!;
        
    }
}