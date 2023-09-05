using Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFeature.Requests.Commands
{
    public class DeleteCategoryCommand : IRequest<BaseResponse<string>>
    {
        public int Id { get; set; }
    }
}
