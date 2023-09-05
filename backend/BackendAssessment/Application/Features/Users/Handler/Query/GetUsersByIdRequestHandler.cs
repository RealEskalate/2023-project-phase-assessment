using Application.DTOs.User;
using Application.Features.Users.Request.Query;
using Application.Persistence.Contracts;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.Handler.Query
{
    public class GetUsersByIdRequestHandler : IRequestHandler<GetUserByIdRequest, GetUserDto>
    {
        public IUserRepository _userRepository { get; set; }
        public IMapper _mapper { get; set; }

        public GetUsersByIdRequestHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetUserDto> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(request.Id);
            return _mapper.Map<GetUserDto>(user);
        }
    }
}