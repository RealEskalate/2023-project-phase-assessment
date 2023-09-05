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
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, BaseResponse<List<ProductResponseDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetAllProductsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse<List<ProductResponseDTO>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {

            var result = await _unitOfWork.ProductRepository.GetAll();

            return new BaseResponse<List<ProductResponseDTO>>()
            {
                Success = true,
                Message = "All products are retrieved successfully",
                Value = _mapper.Map<List<ProductResponseDTO>>(result)
            };
        }
    }
}
