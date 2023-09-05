using Application.Contracts;
using Application.DTOs.User;
using AutoMapper;
using Domain.Entites;
using FluentValidation;
using MediatR;

namespace Application.Features.User.Commands.ToggleUserRole;

public class ToggleUserRoleCommandHandler : IRequestHandler<ToggleUserRoleCommand, UserResponseDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public ToggleUserRoleCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    public async Task<UserResponseDto> Handle(ToggleUserRoleCommand request, CancellationToken cancellationToken)
    {
        var validator = new ToggleUserRoleCommandValidator(_userRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        
        var updatedUser = await _userRepository.GetByIdAsync(request.UserId);
        updatedUser!.IsAdmin = !updatedUser.IsAdmin;
        var userEntity = _mapper.Map<UserEntity>(updatedUser);
        await _userRepository.UpdateAsync(userEntity.Id, userEntity);
        return _mapper.Map<UserResponseDto>(updatedUser);
    }
}