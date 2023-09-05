using Application.DTO.CategoryDTO.DTO;
using Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFeature.Requests.Commands
{
    public class DeleteCategoryCommand : IRequest<BaseResponse<int>>
    {
        public int Id { get; set; }
    }
}
