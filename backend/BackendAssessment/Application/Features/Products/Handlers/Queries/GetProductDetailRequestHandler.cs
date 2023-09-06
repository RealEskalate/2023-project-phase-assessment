using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Persisitence;
using Application.DTOs.Product;
using Application.Exceptions;
using Application.Features.Products.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Products.Handlers.Queries
{
    public class GetProductDetailRequestHandler : IRequestHandler<GetProductDetailRequest, ProductDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;
        public GetProductDetailRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            
        }

        public async Task<ProductDto> Handle(GetProductDetailRequest request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.Get(request.Id);
            
            if(product is null)
                throw new NotFoundException(nameof(product), request.Id);
                
            return _mapper.Map<ProductDto>(product);
        }
    }
}