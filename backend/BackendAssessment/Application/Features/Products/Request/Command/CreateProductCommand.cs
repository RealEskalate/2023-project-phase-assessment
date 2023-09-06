using Application.DTOs.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Request.Command
{
    public class CreateProductCommand : IRequest<CreateProductDTO>
    {
        public string name { get; set; }
        public string description { get; set; }
        public double pricing { get; set; }
        public bool IsAvailable { get; set; }
    }
}
