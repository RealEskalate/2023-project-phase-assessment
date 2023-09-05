using ErrorOr;
using MediatR;

namespace Backend.Application.Features.Auth.Requests.Commands
{
    public class SetRoleCommand : IRequest<ErrorOr<string>>
    {
        public Guid UserId { get; set; }
        public string Role { get; set; } = null!;
    }
}