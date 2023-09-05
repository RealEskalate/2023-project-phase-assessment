using Application.Contracts;
using Application.Exceptions;
using Application.Features.User.Requests.Commands;
using AutoMapper;
using MediatR;

namespace Application.Features.User.Handlers.Commands;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
{   
    private readonly IUserRepository _userRepository;

    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(IUserRepository unitOfWork, IMapper mapper)
    {
        _userRepository = unitOfWork;
        _mapper = mapper;
    }
    

    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var DoesExist = _userRepository.ExistsAsync(request.UpdateUserDto.Id).Result;
        if (!DoesExist)
        {
            throw new NotFoundException(nameof(User), request.UpdateUserDto.Id);
        }
        
        var userToUpdate = await _userRepository.GetByIdAsync(request.UpdateUserDto.Id);

        _mapper.Map(request.UpdateUserDto, userToUpdate);
        await _userRepository.UpdateAsync(userToUpdate!);
        return Unit.Value;
    }
}