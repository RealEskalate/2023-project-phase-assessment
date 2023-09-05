using Application.Contracts;
using Application.Dtos;
using Application.Features.User.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.User.Handlers.Queries;

public class GetAllUsersRequestHandler : IRequestHandler<GetAllUsersRequest, List<UserDto>>
{

    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetAllUsersRequestHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
  
    public async Task<List<UserDto>> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
    {
        var userList = await _userRepository.GetAllAsync();
        return _mapper.Map<List<UserDto>>(userList);
    }
}