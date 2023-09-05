using Application.Contracts.persistence;
using Application.Dtos.Product;
using Application.Features.Products.Request.Queries;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Handler.Queries
{
    public class GetProductDetailsRequestHandler : IRequestHandler<GetProductDetailsRequest, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetProductDetailsRequestHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;

        }
        public async Task<ProductDto> Handle(GetProductDetailsRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(request.Id);
            return _mapper.Map<ProductDto>(product);
        }
    }
}
