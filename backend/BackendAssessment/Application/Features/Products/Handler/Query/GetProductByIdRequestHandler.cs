using Application.DTOs.Product;
using Application.Features.Products.Request.Query;
using Application.Persistence.Contracts;
using AutoMapper;
using MediatR;

namespace Application.Features.Products.Handler.Query
{
    public class GetProductByIdRequestHandler : IRequestHandler<GetProductByIdRequest, GetProductDto>
    {
        public IProductRepository _productRepository { get; set; }
        public IMapper _mapper { get; set; }

        public GetProductByIdRequestHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<GetProductDto> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(request.Id);
            return _mapper.Map<GetProductDto>(product);
        }
    }
}