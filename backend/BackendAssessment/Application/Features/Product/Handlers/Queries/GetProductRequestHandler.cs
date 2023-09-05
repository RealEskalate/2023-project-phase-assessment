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
    public class GetProductRequestHandler : IRequestHandler<GetProductRequest, BaseCommandResponse<ProductDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProductRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse<ProductDto>> Handle(GetProductRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var products = await _unitOfWork.productRepository.Get(request.Id);
                if (products == null)
                {
                    throw new NotFoundException(nameof(Domain.Entites.Product), request.Id);
                }

                var productstDtos = _mapper.Map<ProductDto>(products);
                return BaseCommandResponse<ProductDto>.SuccessHandler(productstDtos);
            }
            catch (Exception ex)
            {

                return BaseCommandResponse<ProductDto>.FailureHandler(ex);
            }
        }
    }
}
