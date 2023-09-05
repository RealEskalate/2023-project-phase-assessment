// using AutoMapper;
// using Backend.Application.DTOs.Product;
// using Backend.Application.Features.Product;
// using Backend.Application.Persistence.Contracts;
// using ErrorOr;
// using MediatR;

// namespace Backend.Application.Features.Product;

// public class PostProductCommandHandler : IRequestHandler<PostProductCommand, ErrorOr<ProductDto>>
// {
//     private readonly IProductRepository _productRepository;
//     private readonly IMapper _mapper;

//     public PostProductCommandHandler(IProductRepository productRepository, IMapper mapper)
//     {
//         _productRepository = productRepository;
//         _mapper = mapper;
//     }

//     public Task<ErrorOr<ProductDto>> Handle(PostProductCommand request, CancellationToken cancellationToken)
//     {
//         var product = _mapper.Map<Product>(req)
//     }
// }