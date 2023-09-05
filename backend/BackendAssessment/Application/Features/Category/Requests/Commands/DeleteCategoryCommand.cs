using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Category.Requests.Commands
{
    public class DeleteCategoryCommand : IRequest<BaseCommandResponse<Unit>>
    {
        public required int Id { get; set; }
    }
}
