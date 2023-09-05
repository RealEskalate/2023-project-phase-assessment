
using Application.DTO.ProductDTO.DTO;
using Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeature.Requests.Commands
{
   public class UpdateProductCommand : IRequest<BaseResponse<ProductResponseDTO>>
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public ProductUpdateDTO? ProductUpdateData { get; set; }
    }
}
