using Application.DTOs.Products;
using Application.Features.Products.Request.Command;
using ErrorOr;
using MediatR;
using Domain.Errors;
using Domain.Entites;
using Application.Contracts;
using AutoMapper;
using Application.DTOs.Users;

namespace Application.Features.Products.Handler.Command
{
    public class DeleteUserRequestHandler : IRequestHandler<DeleteUserRequest, ErrorOr<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public DeleteUserRequestHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<UserDto>> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserById(request.UserId);

            // check if user exists
            if (user == null)
            {
                return Errors.User.UserNotFound;
            }

            // check if user is admin
            if (user.IsAdmin == false)
            {
                return Errors.Auth.AdminAccessRequired;
            }

            var toBeDeleted = _mapper.Map<User>(user);

            var result = await _userRepository.DeleteUser(toBeDeleted);

            if (result == null)
            {
                return Errors.User.UserNotDeleted;
            }

            return _mapper.Map<UserDto>(result);
        }
    }
}
