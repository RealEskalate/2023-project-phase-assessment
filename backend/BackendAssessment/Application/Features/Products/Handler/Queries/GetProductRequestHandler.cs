using Application.Contracts;
using Application.DTOs.Products;
using Application.Features.Products.Request.Queries;
using AutoMapper;
using ErrorOr;
using MediatR;
using Domain.Errors;
namespace Application.Features.Products.Handler.Queries
{
    public class GetProductRequestHandler : IRequestHandler<GetProductRequest, ErrorOr<ProductResponseDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetProductRequestHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<ProductResponseDto>> Handle(GetProductRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductById(request.Id);
            if (product == null)
            {
                return Errors.Product.ProductNotFound;
            }

            var response = _mapper.Map<ProductResponseDto>(product);
            return response;
            
        }
    }
}