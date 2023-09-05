
using Application.Contracts;
using Application.Dtos;
using Application.Exceptions;
using Application.Features.User.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.User.Handlers.Queries;

public class GetUserByIdRequestHandler : IRequestHandler<GetUserByIdRequest, UserDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUserByIdRequestHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
    {
        var DoesExist = await _userRepository.ExistsAsync(request.Id);

        if (!DoesExist)
        {
            throw new NotFoundException(nameof(User), request.Id);
        }

        var user = await _userRepository.GetByIdAsync(request.Id);

        return _mapper.Map<UserDto>(user);
    }
    
}
