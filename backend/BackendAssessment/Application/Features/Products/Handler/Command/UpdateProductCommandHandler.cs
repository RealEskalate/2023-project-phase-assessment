using Application.DTO.Product;
using Application.Features.Products.Request.Command;
using MediatR;
using Application.Persistance.Contracts;
using AutoMapper;

namespace Application.Features.Products.Handler.Command
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, GetProductDTO>
    {
        public IProductRepository _productRepository { get; set; }
        public IMapper _mapper { get; set; }

        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<GetProductDTO> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var prodId = request.updateProductDTO.Id;
            var product = await _productRepository.Get(prodId);

            if (product == null)
                throw new Exception($"Product with ID {prodId} not found");

            _mapper.Map(request.updateProductDTO, product);
            await _productRepository.Update(product);

            var updatedProductDto = _mapper.Map<GetProductDTO>(product);

            return updatedProductDto;
        }

    }
}