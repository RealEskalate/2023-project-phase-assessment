using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product.Requests.Commands
{
    public class DeleteProductCommand : IRequest<BaseCommandResponse<Unit>>
    {
        public required int Id { get; set; }
    }
}
