using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Errors;
using Application.Contracts;
using Application.DTOs.Products;
using Application.Features.Products.Request.Command;
using AutoMapper;
using ErrorOr;
using MediatR;
using Domain.Entites;
using Application.DTOs.Products.Validators;
using Application.DTOs.Users;

namespace Application.Features.Products.Handler.Command
{
    public class UpdateUserRequestHandler : IRequestHandler<UpdateUserRequest, ErrorOr<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserRequestHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<UserDto>> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserById(request.UserId);
            
            // check if user exists
            if(user == null){
                return Errors.User.UserNotFound;
            }

            // check if user is admin
            if(user.IsAdmin == false)
            {
                return Errors.Auth.AdminAccessRequired;
            }

            var toBeUpdated = _mapper.Map<User>(user);

            var result = await _userRepository.UpdateUser(toBeUpdated);

            if (result == null)
            {
                return Errors.User.UserNotUpdated;
            }

            return _mapper.Map<UserDto>(result);
        }
    }
}