using Application.Contracts;
using Application.Features.User.Requests.Commands;
using AutoMapper;
using MediatR;
using Domain.Entities;
using Application.Dtos.User.Valiation;
using Application.Exceptions;

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

        var validator = new CreateUserDtoValidator(_userRepository);
        var validationResult = await validator.ValidateAsync(request.CreateUserDto, cancellationToken);

        if (validationResult.Errors.Count > 0)
        {
            throw new ValidationErrorException(validationResult);
        }

        

        var user = _mapper.Map<Domain.Entities.User>(request.CreateUserDto);
        await _userRepository.AddAsync(user);
        return user.Id;
    }
}