using Application.DTO.Categories;
using Application.DTO.Products;
using Application.Features.Products.Request.Command;
using Application.Persistance.Contracts;
using AutoMapper;
using Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Handler.Command
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductDto>
    {
        public IProductRepository _productRepository { get; set; }
        public IMapper _mapper { get; set; }

        public CreateProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request.productDto);

            product = await _productRepository.Add(product);

            return _mapper.Map<ProductDto>(product); ;
        }
    }
}
