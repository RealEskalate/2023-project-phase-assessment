using Application.DTOs.Category;
using Application.DTOs.User;
using Application.Features.Users.Request.Command;
using AutoMapper;
using MediatR;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Handler.Command
{
    internal class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, CreateUserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository i, IMapper mapper)
        {
            _userRepository = i;
            _mapper = mapper;
        }
        public async Task<CreateUserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var category = await _userRepository.Get(request.Id)!;
            if (category == null)
            {
                throw new Exception();
            }

            var categoryToUpdate = _mapper.Map(request, category);
            var updatedCategory = await _userRepository.Update(categoryToUpdate);
            return _mapper.Map<CreateUserDto>(updatedCategory);

        }
    }
}
