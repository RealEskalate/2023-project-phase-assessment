using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Catagory;
using MediatR;

namespace Application.Features.Catagories.Requests.Commands
{
    public class UpdateCatagoryCommand : IRequest<Unit>
    {
        public required UpdateCatagoryDto UpdateCatagoryDto { get; set; }
        public Guid RequestingUserId { get; set; }
    }
}