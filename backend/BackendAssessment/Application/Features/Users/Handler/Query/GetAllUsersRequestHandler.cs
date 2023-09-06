using Application.DTO.User;
using Application.Features.Users.Request.Query;
using Application.Persistance.Contracts;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.Handler.Query
{
    public class GetAllUsersRequestHandler : IRequestHandler<GetAllUsersRequest, List<GetUserDTO>>
    {
        public IUserRepository _userRepository { get; set; }
        public IMapper _mapper { get; set; }

        public GetAllUsersRequestHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<List<GetUserDTO>> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAll();
            return _mapper.Map<List<GetUserDTO>>(users);
        }
    }
}