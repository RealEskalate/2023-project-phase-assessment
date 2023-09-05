using Application.DTO.Product;
using Application.Features.Products.Request.Query;
using Application.Persistance.Contracts;
using AutoMapper;
using MediatR;

namespace Application.Features.Products.Handler.Query
{
    public class GetProductByIdRequestHandler : IRequestHandler<GetProductByIdRequest, GetProductDTO>
    {
        public IProductRepository _productRepository { get; set; }
        public IMapper _mapper { get; set; }

        public GetProductByIdRequestHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<GetProductDTO> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.Get(request.Id);
            return _mapper.Map<GetProductDTO>(product);
        }
    }
}