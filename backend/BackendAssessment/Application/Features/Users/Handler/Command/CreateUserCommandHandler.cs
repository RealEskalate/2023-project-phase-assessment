using Application.Features.Users.Request.Command;
using Application.Persistence.Contracts;
using AutoMapper;
using MediatR;
using Domain.Entites;

namespace Application.Features.Users.Handler.Command
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Unit>
    {

        public IUserRepository _userRepository { get; set; }
        public IMapper _mapper { get; set; }

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userEntity = _mapper.Map<User>(request.CreateUserDto);
            await _userRepository.Add(userEntity);

            return Unit.Value;
        }
    }
}