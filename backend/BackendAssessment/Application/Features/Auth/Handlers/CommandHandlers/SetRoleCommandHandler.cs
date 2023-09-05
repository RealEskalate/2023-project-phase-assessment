using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Application.Features.Auth.Requests.Commands;
using Backend.Application.Persistence.Contracts;
using Backend.Domain.Entities;
using ErrorOr;
using MediatR;
namespace Backend.Application.Features.Auth.Handlers.CommandHandlers{

    public class SetRoleCommandHandler : IRequestHandler<SetRoleCommand, ErrorOr<string>>
    {
        private readonly IUserRepository _userRepository;

        public SetRoleCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<string>> Handle(SetRoleCommand request, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetUserById(request.UserId);
            if (user == null){
                ErrorOr<string> res = "User not found";
                return res;
            }
            
            if(await _userRepository.SetRole(request.UserId, request.Role) == false)
                throw new Exception("Role not set");

            ErrorOr<string> result = "Role set";
            return result;
        }
    }
}