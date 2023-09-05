using Application.Contracts;
using Application.DTOs.User;
using AutoMapper;
using Domain.Entites;
using FluentValidation;
using MediatR;

namespace Application.Features.User.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserResponseDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserResponseDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateUserCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var user = _mapper.Map<UserEntity>(request.UserDto);
        user.Password = BCrypt.Net.BCrypt.HashPassword(request.UserDto.Password);
        var res = await _userRepository.CreateAsync(user);
        return _mapper.Map<UserResponseDto>(res);
    }
}