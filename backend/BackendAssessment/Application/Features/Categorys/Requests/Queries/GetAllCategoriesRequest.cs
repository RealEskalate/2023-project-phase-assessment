using Application.DTOs.Categorys;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categorys.Requests.Queries
{
    public class GetAllCategoriesRequest : IRequest<List<CategoryDetailsDto>>
    {
    }
}
