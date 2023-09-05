using Application.DTO.ProductCategoryDTO;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductCategory.Requests.Commands
{
    public class DeleteProductCategoryCommand : IRequest<BaseCommandResponse<Unit>>
    {
        public required ProductCategoryDto ProductCategoryDto { get; set; }
    }
}
