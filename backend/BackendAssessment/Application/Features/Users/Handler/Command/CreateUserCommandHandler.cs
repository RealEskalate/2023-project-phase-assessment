using Application.DTOs.Category;
using Application.DTOs.User;
using Application.Features.Users.Request.Command;
using AutoMapper;
using Domain.Entites;
using MediatR;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Handler.Command
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository i, IMapper mapper)
        {
            _userRepository = i;
            _mapper = mapper;
        }
        public async Task<CreateUserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            var result = await _userRepository.Add(user);

            var response = _mapper.Map<CreateUserDto>(result);
            return response;
        }
    }
}
