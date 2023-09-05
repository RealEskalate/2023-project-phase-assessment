using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Request.Commands
{
    public class DeleteCategoryRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
