using Application.DTO.Products;
using Application.DTO.Users;
using Application.Features.Products.Request.Command;
using Application.Features.Users.Request.Command;
using Application.Persistance.Contracts;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Handler.Command
{
    public  class UpdateProductHandler: IRequestHandler<UpdateProductCommand, ProductDto>
    {
        public IProductRepository _productRepository { get; set; }
        public IMapper _mapper { get; set; }

        public UpdateProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productId = request.product.Id;
            var product = await _productRepository.GetById(productId);

            if (product == null)
                throw new Exception($"User with ID {productId} not found");

            _mapper.Map(request.product, product);
            await _productRepository.Update(product);

            return _mapper.Map<ProductDto>(product);
        }
    }
    
}
