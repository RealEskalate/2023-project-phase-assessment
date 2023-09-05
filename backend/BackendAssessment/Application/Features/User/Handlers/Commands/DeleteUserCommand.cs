using Application.Contracts;
using Application.Exceptions;
using Application.Features.User.Requests.Commands;
using AutoMapper;
using MediatR;

namespace Application.Features.User.Handlers.Commands;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
{   

    private readonly IUserRepository _userRepository;

    private readonly IMapper _mapper;

    public DeleteUserCommandHandler(IUserRepository unitOfWork, IMapper mapper)
    {
        _userRepository = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
       var DoesExist = _userRepository.GetByIdAsync(request.Id).Result ?? throw new NotFoundException(nameof(User), request.Id);
        var userToDelete = await _userRepository.GetByIdAsync(request.Id);
        await _userRepository.DeleteAsync(userToDelete!);
        return Unit.Value;

    }
}