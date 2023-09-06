using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Features.Catagories.Requests.Commands
{
    public class DeleteCatagoryCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public Guid RequestingUserId { get; set; }
    }
}