using Application.DTOs.Product;
using Application.Features.Products.Request.Command;
using MediatR;
using Application.Persistence.Contracts;
using AutoMapper;
using Domain.Entites;

namespace Application.Features.Products.Handler.Command
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, GetProductDto>
    {
        public IProductRepository _productRepository { get; set; }
        public IMapper _mapper { get; set; }

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<GetProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productEntity = _mapper.Map<Product>(request.createProductDTO);
            await _productRepository.Add(productEntity);

            return _mapper.Map<GetProductDto>(productEntity);
        }
    }
}