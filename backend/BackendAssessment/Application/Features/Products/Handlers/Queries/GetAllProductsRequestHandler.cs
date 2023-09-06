using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Persisitence;
using Application.DTOs.Product;
using Application.Features.Products.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Products.Handlers.Queries
{
    public class GetAllProductsRequestHandler : IRequestHandler<GetAllProductsRequest, List<ProductListDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;
        public GetAllProductsRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            
        }

        public async Task<List<ProductListDto>> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.ProductRepository.GetAll(request.PageIndex, request.PageSize);
            return _mapper.Map<List<ProductListDto>>(products);
        }
    }
}