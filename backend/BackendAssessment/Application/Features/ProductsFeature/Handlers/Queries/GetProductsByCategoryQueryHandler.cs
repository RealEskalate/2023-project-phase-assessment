using Application.Common;
using Application.Contracts;
using Application.DTO.Product.DTO;
using Application.Features.ProductsFeature.Requests.Queries;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductsFeature.Handlers.Queries
{
    public class GetProductsByCategoryQueryHandler : IRequestHandler<GetProductsByCategoryQuery, BaseResponse<List<ProductResponseDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetProductsByCategoryQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse<List<ProductResponseDTO>>> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken)
        {

            var result = await _unitOfWork.ProductRepository.GetProductsByCategory(request.category);

            return new BaseResponse<List<ProductResponseDTO>>
            {
                Success = true,
                Message = "Products by Category",
                Value = _mapper.Map<List<ProductResponseDTO>>(result)
            };
        }
    }
}
