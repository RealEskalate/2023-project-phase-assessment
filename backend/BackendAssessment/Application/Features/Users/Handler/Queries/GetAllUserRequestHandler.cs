using Application.Contracts;
using Application.DTOs.Products;
using Application.Features.Products.Request.Queries;
using AutoMapper;
using ErrorOr;
using MediatR;
using Domain.Errors;
using Domain.Entites;
using Application.DTOs.Users;

namespace Application.Features.Products.Handler.Queries
{
    public class GetAllUserRequestHandler : IRequestHandler<GetAllUserRequest, ErrorOr<List<UserDto>>>
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllUserRequestHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        
        public async Task<ErrorOr<List<UserDto>>> Handle(GetAllUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserById(request.UserId);

            if (user == null)
            {
                return Errors.User.UserNotFound;
            }

            if (user.IsAdmin == false)
            {
                return Errors.Auth.AdminAccessRequired;
            }

            var users = await _userRepository.GetAllUsers();
            return _mapper.Map<List<UserDto>>(users);
        }
    }
}