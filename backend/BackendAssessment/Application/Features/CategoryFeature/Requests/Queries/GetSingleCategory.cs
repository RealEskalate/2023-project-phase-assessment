using Application.DTO.CategoryDTO.DTO;
using Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFeature.Requests.Queries
{
    public class GetSingleCategoryQuery : IRequest<BaseResponse<CategoryResponseDTO>>
    {
        public int Id { get; set; }        
    }
}


