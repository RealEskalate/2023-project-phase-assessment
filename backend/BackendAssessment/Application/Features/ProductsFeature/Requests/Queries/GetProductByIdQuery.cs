using Application.Common;
using Application.DTO.Product.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductsFeature.Requests.Queries
{
    public class GetProductByIdQuery : IRequest<BaseResponse<ProductResponseDTO>>
    {
        public int Id { get; set; }
    }
}
