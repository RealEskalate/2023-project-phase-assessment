using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Catagory;
using MediatR;

namespace Application.Features.Catagories.Requests.Queries
{
    public class GetAllCatagoriesRequest : IRequest<List<CatagoryListDto>>
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}