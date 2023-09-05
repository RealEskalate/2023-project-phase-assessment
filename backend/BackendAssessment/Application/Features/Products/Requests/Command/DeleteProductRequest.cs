using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Requests.Command
{
    public class DeleteProductRequest : IRequest<Unit>
    {
        public int Id { get; set; } 
    }
}
