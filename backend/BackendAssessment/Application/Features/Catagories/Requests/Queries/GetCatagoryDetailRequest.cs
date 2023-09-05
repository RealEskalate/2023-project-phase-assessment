using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Catagory;
using Domain.Entites;
using MediatR;

namespace Application.Features.Catagories.Requests.Queries
{
    public class GetCatagoryDetailRequest : IRequest<CatagoryDto>
    {
        public Guid Id { get; set; }
    }
}