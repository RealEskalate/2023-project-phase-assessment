using Application.DTO.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Request.Query
{
    public class GetUserByIdQuery : IRequest<GetUserDto>
    {
        public Guid Id { get; set; }
    }
}
