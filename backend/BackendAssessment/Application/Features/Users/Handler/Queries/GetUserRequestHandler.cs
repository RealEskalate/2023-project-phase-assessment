using Application.Contracts;
using Application.DTOs.Products;
using Application.Features.Products.Request.Queries;
using AutoMapper;
using ErrorOr;
using MediatR;
using Domain.Errors;
using Application.DTOs.Users;
namespace Application.Features.Products.Handler.Queries
{
    public class GetUserRequestHandler : IRequestHandler<GetUserRequest, ErrorOr<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetUserRequestHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<UserDto>> Handle(GetUserRequest request, CancellationToken cancellationToken)
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

            return _mapper.Map<UserDto>(user);            
        }
    }
}