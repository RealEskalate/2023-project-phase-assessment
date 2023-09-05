using Application.Contracts;
using Application.Dtos.User;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;

namespace Application.Features.User.Commands.Create;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserResponseDto>
{
    private IMapper _mapper;
    private IUserRepository _userRepository;
    public CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper; 
        _userRepository = userRepository;  
    }
    public async Task<UserResponseDto> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateUserValidator();
        var validationResult = await validator.ValidateAsync(command.NewUser, cancellationToken);
        
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var new_user = _mapper.Map<UserEntity>(command.NewUser);
        var created_user = await _userRepository.CreateAsync(new_user,cancellationToken);

        return _mapper.Map<UserResponseDto>(created_user);
    }
}