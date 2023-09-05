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
    public class CreateUserCommandHandler : IRequestHandler<CreateUserRequest, User>
    {
        public IUserRepository _userRepository;
        public IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            userRepository = _userRepository;
            mapper = _mapper;

        }
        public async Task<User> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request.User);
            user = await _userRepository.Add(user);

            return user;
        }
           
        
        
    }
}
