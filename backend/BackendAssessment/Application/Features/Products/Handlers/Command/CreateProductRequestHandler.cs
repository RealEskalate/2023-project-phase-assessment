using Application.Contracts;
using Application.DTOs.Products.Validation;
using Application.DTOs.Products;
using Application.Exceptions;
using Application.Features.Products.Requests.Command;
using AutoMapper;
using Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Handlers.Command
{
    public class CreateProductRequestHandler : IRequestHandler<CreateProductRequest, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateProductRequestHandler(IProductRepository productRepository, IMapper mapper, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task<ProductDto> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateProductDtoValidator(_categoryRepository);

            var validationResult =  await validator.ValidateAsync(request.CreateProductDto);

            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }

            var product = _mapper.Map<Product>(request.CreateProductDto);

            await _productRepository.AddAsync(product);

        }
    }
}
