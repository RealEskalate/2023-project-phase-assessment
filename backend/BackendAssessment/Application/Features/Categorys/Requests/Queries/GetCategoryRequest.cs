using Application.DTOs.Categorys;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categorys.Requests.Queries
{
    public class GetCategoryRequest : IRequest<CategoryDetailsDto>
    {
        public int Id { get; set; }
    }
}
