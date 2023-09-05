using Application.DTO.User;
using Application.Features.Users.Request.Query;
using Application.Persistance.Contracts;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.Handler.Query
{
    public class GetUsersByIdRequestHandler : IRequestHandler<GetUserByIdRequest, GetUserDTO>
    {
        public IUserRepository _userRepository { get; set; }
        public IMapper _mapper { get; set; }

        public GetUsersByIdRequestHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetUserDTO> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.Get(request.Id);
            return _mapper.Map<GetUserDTO>(user);
        }
    }
}