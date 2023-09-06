using Application.Contracts;
using Application.DTOs.Products;
using Application.Features.Products.Request.Queries;
using AutoMapper;
using ErrorOr;
using MediatR;
using Domain.Errors;

namespace Application.Features.Products.Handler.Queries
{
    public class GetAllProductRequestHandler : IRequestHandler<GetAllProductRequest, ErrorOr<List<ProductResponseDto>>>
    {

        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllProductRequestHandler(IProductRepository productRepository, IUserRepository userRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        
        public async Task<ErrorOr<List<ProductResponseDto>>> Handle(GetAllProductRequest request, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetUserById(request.UserId);

            // check if user exists
            if (user == null)
            {
                return Errors.User.UserNotFound;
            }

            var products = await _productRepository.GetAllProducts();

            return _mapper.Map<List<ProductResponseDto>>(products);
        }
    }
}