using Application.Features.Users.Request.Command;
using Application.Persistence.Contracts;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.Handler.Command
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        public IUserRepository _userRepository { get; set; }
        public IMapper _mapper { get; set; }

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userId = request.UpdateUserDTO.Id;
            var user = await _userRepository.GetById(userId);

            if (user == null)
                throw new Exception($"User with ID {userId} not found");

            _mapper.Map(request.UpdateUserDTO, user);
            await _userRepository.Update(user);
            return Unit.Value;
        }
    }
}