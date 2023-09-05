using Application.Contracts;
using Application.Dtos.User;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;

namespace Application.Features.User.Commands.Delete;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
{
    private IMapper _mapper;
    private IUserRepository _userRepository;
    public DeleteUserCommandHandler(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper; 
        _userRepository = userRepository;  
    }

    public async Task<Unit> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetSingleAsync(command.UserId,cancellationToken);
        if(user == null)
            throw new Exception("User Id not found");
        await _userRepository.DeleteAsync(user,cancellationToken);
        return Unit.Value;
    }
}