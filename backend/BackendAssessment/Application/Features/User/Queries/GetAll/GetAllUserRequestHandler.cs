using Application.Contracts;
using Application.Dtos.User;
using AutoMapper;
using MediatR;

namespace Application.Features.User.Queries.GetAll;

public class GetAllUserRequestHandler : IRequestHandler<GetAllUserRequest, IReadOnlyList<UserResponseDto>>
{
    private IMapper _mapper;
    private IUserRepository _userRepository;
    public GetAllUserRequestHandler(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper; 
        _userRepository = userRepository;  
    }

    public async Task<IReadOnlyList<UserResponseDto>> Handle(GetAllUserRequest request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync(cancellationToken);
        
        return _mapper.Map<IReadOnlyList<UserResponseDto>>(users);
    }
}