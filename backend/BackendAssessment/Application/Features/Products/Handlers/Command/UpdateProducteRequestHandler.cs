using Application.Features.Products.Requests.Command;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Handlers.Command
{
    public class UpdateProducteRequestHandler : IRequestHandler<UpdateProductRequest, Unit>
    {
        public Task<Unit> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
