using Application.DTO.ProductDTO;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product.Requests.Querie
{
    public class GetProductRequest : IRequest<BaseCommandResponse<ProductDto>>
    {
        public required int Id { get; set; }
    }
}
