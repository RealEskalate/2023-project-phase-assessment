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
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, GetUserDto>
    {
        public IUserRepository _userRepository;
        public IMapper _mapper;

        public GetUserByIdHandler(IUserRepository userRepository, IMapper mapper)
        {
            userRepository = _userRepository;
            mapper = _mapper;

        }
        public async Task<GetUserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(request.Id);
            return _mapper.Map<GetUserDto>(user);
        }
    }
}
