using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Catagory;
using Application.Responses;
using MediatR;

namespace Application.Features.Catagories.Requests.Commands
{
    public class CreateCatagoryCommand : IRequest<BaseCommandResponse>
    {
        public required CreateCatagoryDto CreateCatagoryDto { get; set; }
        public Guid RequestingUserId { get; set; }
    }
}