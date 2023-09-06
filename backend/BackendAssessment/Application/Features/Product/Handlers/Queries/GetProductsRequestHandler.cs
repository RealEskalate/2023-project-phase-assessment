using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.DTOs.Product;
using Application.Features.Product.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Product.Handlers.Queries
{
    public class GetProductsRequestHandler: IRequestHandler<GetProductsRequest, List<ProductDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;
        public GetProductsRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            
        }
        public async Task<List<ProductDto>> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.ProductRepository.GetAll();
            return _mapper.Map<List<ProductDto>>(products);
        }
    }
}