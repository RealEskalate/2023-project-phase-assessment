using Application.DTOs.Products;
using Application.Features.Products.Request.Command;
using ErrorOr;
using MediatR;
using Domain.Errors;
using Domain.Entites;
using Application.Contracts;
using AutoMapper;

namespace Application.Features.Products.Handler.Command
{
    public class DeleteProductRequestHandler : IRequestHandler<DeleteProductRequest, ErrorOr<ProductResponseDto>>
    {

        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public DeleteProductRequestHandler(IProductRepository productRepository, IUserRepository userRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<ProductResponseDto>> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserById(request.UserId);

            // check if user exists
            if (user == null)
            {
                return Errors.User.UserNotFound;
            }

            // check if user is admin
            if (user.IsAdmin == false)
            {
                return Errors.Auth.AdminAccessRequired;
            }

            var product = _productRepository.GetProductById(request.ProductId);

            // check if product exists
            if (product == null)
            {
                return Errors.Product.ProductNotFound;
            }

            var tobeDeletedProduct = _mapper.Map<Product>(request);

            var productResponse = await _productRepository.DeleteProduct(tobeDeletedProduct);

            return _mapper.Map<ProductResponseDto>(productResponse);
        }
    }
}