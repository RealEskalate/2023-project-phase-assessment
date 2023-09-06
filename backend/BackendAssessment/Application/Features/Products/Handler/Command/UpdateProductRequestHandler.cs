using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Errors;
using Application.Contracts;
using Application.DTOs.Products;
using Application.Features.Products.Request.Command;
using AutoMapper;
using ErrorOr;
using MediatR;
using Domain.Entites;
using Application.DTOs.Products.Validators;

namespace Application.Features.Products.Handler.Command
{
    public class UpdateProductRequestHandler : IRequestHandler<UpdateProductRequest, ErrorOr<ProductResponseDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateProductRequestHandler(IProductRepository productRepository, IUserRepository userRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<ProductResponseDto>> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserById(request.UserId);
            
            // check if user exists
            if(user == null){
                return Errors.User.UserNotFound;
            }

            // check if user is admin
            if(user.IsAdmin == false)
            {
                return Errors.Auth.AdminAccessRequired;
            }

            var product = _productRepository.GetProductById(request.ProductId);

            // check if product exists
            if(product == null){
                return Errors.Product.ProductNotFound;
            }

            var validator = new ProductDtoValidator();
            var validationResult = validator.Validate(request.ProductDetailDto);

            if (!validationResult.IsValid)
            {
                return Errors.Product.InvalidProduct;
            }

            var updatedProduct = _mapper.Map<Product>(request);
            var productResponse = await _productRepository.UpdateProduct(updatedProduct);

            return _mapper.Map<ProductResponseDto>(productResponse);
            
        }
    }
}