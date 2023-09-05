using Application.DTOs.Category;
using Application.DTOs.User;
using Application.Features.Users.Request.Queries;
using AutoMapper;
using MediatR;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Handler.Queries
{
    public class GetUserRequestHandler : IRequestHandler<GetUserRequest, CreateUserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;



        public GetUserRequestHandler(IUserRepository i, IMapper mapper)
        {
            _userRepository = i;
            _mapper = mapper;
        }
        public async Task<CreateUserDto> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.Get(request.Id)!;
            if (user == null)
            {
                throw new Exception();
            }
            return _mapper.Map<CreateUserDto>(user);
        }
    }
}
