using Application.Contracts;
using Application.Features.User.Requests.Commands;
using AutoMapper;
using MediatR;
using Domain.Entities;

namespace Application.Features.User.Handlers.Commands;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<Domain.Entities.User>(request.CreateUserDto);
        await _userRepository.AddAsync(user);
        return user.Id;
    }
}