using Application.Common;
using Application.DTO.Product.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductsFeature.Requests.Commands
{
    public class CreateProductCommand : IRequest<BaseResponse<ProductResponseDTO>>
    {
        public ProductCreateDTO ProductData { get; set; }
    }
}
