using Application.DTO.Users;
using Application.Features.Users.Request.Query;
using Application.Persistance.Contracts;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Handler.Query
{
    public class GetAllUserHandler : IRequestHandler<GetAllUserQuery, List<GetUserDto>>
    {
        public IUserRepository _userRepository;
        public IMapper _mapper;

        public GetAllUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            userRepository = _userRepository;
            mapper = _mapper;
            
        }
        public async Task<List<GetUserDto>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAll();

            return _mapper.Map<List<GetUserDto>>(users);
        }

       
    }
}
