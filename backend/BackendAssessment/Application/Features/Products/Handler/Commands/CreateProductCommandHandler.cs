using Application.Contracts.persistence;
using Application.Dtos.Product.Validator;
using Application.Exceptions;
using Application.Features.Products.Request.Commands;
using AutoMapper;
using Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Handler.Commands
{
    internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public CreateProductCommandHandler(IUserRepository userRepository, ICategoryRepository categoryRepository, IMapper mapper, IProductRepository product)
        {
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _productRepository = product;
        }
        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var validation = new CreateProductValidator(_userRepository, _categoryRepository);
            var validationResult = await validation.ValidateAsync(request.CreateProductDto, cancellationToken);
            if (validationResult.IsValid == true)
            {
                var product = _mapper.Map<Product>(request.CreateProductDto);
                product = await _productRepository.Add(product);
                return product.Id;
            }
            else
            {
                throw new ValidationException(validationResult);
            }
            
        }
    }
}
