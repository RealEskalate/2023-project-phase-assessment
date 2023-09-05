using Application.Contracts;
using Application.Dtos.User;
using AutoMapper;
using MediatR;

namespace Application.Features.User.Queries.GetSingle;

public class GetSingleUserRequestHandler : IRequestHandler<GetSingleUserRequest, UserResponseDto>
{
    private IMapper _mapper;
    private IUserRepository _userRepository;
    public GetSingleUserRequestHandler(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper; 
        _userRepository = userRepository;  
    }

    public async Task<UserResponseDto> Handle(GetSingleUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetSingleAsync(request.UserId,cancellationToken);
        if(user == null)
            throw new Exception("User Id not found");
        
        return _mapper.Map<UserResponseDto>(user);
    }
}