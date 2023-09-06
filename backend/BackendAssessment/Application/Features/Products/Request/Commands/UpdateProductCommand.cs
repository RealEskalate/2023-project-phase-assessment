using Application.Dtos.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Request.Commands
{
    public class UpdateProductCommand : IRequest<Unit>
    {
        public UpdateProductDto UpdateProductDto { get; set; }
    }
}
