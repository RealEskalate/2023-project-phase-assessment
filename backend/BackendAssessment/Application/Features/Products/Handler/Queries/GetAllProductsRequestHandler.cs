using Application.Contracts.persistence;
using Application.Dtos.Product;
using Application.Features.Products.Request.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Handler.Queries
{
    public class GetAllProductsRequestHandler : IRequestHandler<GetAllProductsRequest, List<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetAllProductsRequestHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            
        }
        public async Task<List<ProductDto>> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetProductByUserId(request.UserId);
            return _mapper.Map<List<ProductDto>>(products);
        }
    }
}
