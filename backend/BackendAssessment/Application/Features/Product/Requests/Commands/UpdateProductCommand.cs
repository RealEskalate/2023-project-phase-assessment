using Application.DTO.ProductDTO;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product.Requests.Commands
{
    public class UpdateProductCommand : IRequest<BaseCommandResponse<Unit>>
    {
        public required ProductDto Product { get; set; }
    }
}
