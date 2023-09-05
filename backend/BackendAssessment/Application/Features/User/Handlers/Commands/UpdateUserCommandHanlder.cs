using Application.Contracts;
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
        var userToUpdate = _userRepository.GetByIdAsync(request.UpdateUserDto.Id).Result;
        _mapper.Map(request.UpdateUserDto, userToUpdate);
        await _userRepository.UpdateAsync(userToUpdate);
        return Unit.Value;
    }
}