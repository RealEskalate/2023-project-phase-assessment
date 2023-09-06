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
    public class SearchProductsByNameRequestHandler : IRequestHandler<SearchProductsByNameRequest, List<ProductListDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;
        public SearchProductsByNameRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            
        }

        public async Task<List<ProductListDto>> Handle(SearchProductsByNameRequest request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.ProductRepository.SearchProductsByName(request.Name, request.PageIndex, request.PageSize);
            return _mapper.Map<List<ProductListDto>>(products);
        }
    }
}