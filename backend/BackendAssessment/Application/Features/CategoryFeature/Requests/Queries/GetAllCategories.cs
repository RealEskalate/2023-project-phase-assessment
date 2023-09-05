using Application.DTO.ProductDTO.DTO;
using Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeature.Requests.Queries
{
    public class GetAllCategoriesQuery : IRequest<BaseResponse<List<ProductResponseDTO>>>{}
}
