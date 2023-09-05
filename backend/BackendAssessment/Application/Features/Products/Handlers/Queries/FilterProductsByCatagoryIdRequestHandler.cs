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
    public class FilterProductsByCatagoryIdRequestHandler : IRequestHandler<FilterProductsByCatagoryIdRequest, List<ProductsByCatagoryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;
        public FilterProductsByCatagoryIdRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            
        }
        public async Task<List<ProductsByCatagoryDto>> Handle(FilterProductsByCatagoryIdRequest request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.ProductRepository.FilterProductsByCatagoryId(request.CatagoryId, request.PageIndex, request.PageSize);
            return _mapper.Map<List<ProductsByCatagoryDto>>(products);
        }
    }
}