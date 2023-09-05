using Application.Contracts;
using Application.Dtos.User;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;

namespace Application.Features.User.Commands.Update;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserResponseDto>
{
    private IMapper _mapper;
    private IUserRepository _userRepository;
    public UpdateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper; 
        _userRepository = userRepository;  
    }
    public async Task<UserResponseDto> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var validator = new UpdateUserValidator();
        var validationResult = await validator.ValidateAsync(command.UpdateUser, cancellationToken);
        
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        var old_user = await _userRepository.GetSingleAsync(command.UserId,cancellationToken);
        if(old_user == null)
            throw new Exception("user not found");
            
        var new_user = _mapper.Map<UserEntity>(command.UpdateUser);
        var updated_user = await _userRepository.UpdateAsync(old_user,new_user,cancellationToken);

        return _mapper.Map<UserResponseDto>(updated_user);
    }
}