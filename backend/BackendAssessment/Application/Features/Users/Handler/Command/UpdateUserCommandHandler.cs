using Application.DTO.Categories;
using Application.DTO.Users;
using Application.Features.Users.Request.Command;
using Application.Persistance.Contracts;
using AutoMapper;
using Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Handler.Command
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserRequest, UserDto>
    {
        public IUserRepository _userRepository { get; set; }
        public IMapper _mapper { get; set; }

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserDto> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var userId = request.user.Id;
            var user = await _userRepository.GetById(userId);

            if (user == null)
                throw new Exception($"User with ID {userId} not found");

            _mapper.Map(request.user, user);
            await _userRepository.Update(user);

            return _mapper.Map<UserDto>(user);
        }
    }
}
