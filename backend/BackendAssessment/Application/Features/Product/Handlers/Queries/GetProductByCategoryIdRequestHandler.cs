using Application.Contracts.Persistance;
using Application.DTO.ProductDTO;
using Application.Exceptions;
using Application.Features.Product.Requests.Querie;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product.Handlers.Queries
{
    public class GetProductByCategoryIdRequestHandler : IRequestHandler<GetProductsByCategoryIdRequest, BaseCommandResponse<List<ProductDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProductByCategoryIdRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse<List<ProductDto>>> Handle(GetProductsByCategoryIdRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var categoryId = await _unitOfWork.productRepository.Get(request.CategoryId);
                if (categoryId is null)
                {
                    throw new NotFoundException(nameof(categoryId), request.CategoryId);
                }
                return BaseCommandResponse<List<ProductDto>>.SuccessHandler(_mapper.Map<List<ProductDto>>(categoryId));
            }
            catch (Exception ex)
            {
                return BaseCommandResponse<List<ProductDto>>.FailureHandler(ex);
            }
        }
    }
}
