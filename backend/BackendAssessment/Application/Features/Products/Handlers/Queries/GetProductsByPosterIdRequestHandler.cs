// using Application.Contracts.Persistence;
// using AutoMapper;
// using BackendAssessment.Application.Common.Exceptions;
// using BackendAssessment.Application.Contracts.Persistence;
// using BackendAssessment.Application.DTOs.ProductDtos;
// using BackendAssessment.Application.Features.Products.Requests.Queries;
// using BackendAssessment.Domain.Entities;
// using MediatR;

// namespace Application.Features.Productss.Handlers.Queries;

// public class GetProductsByUserIdRequestHandler : IRequestHandler<GetProductsByUserIdRequest, List<ProductDto>>
// {
//     private readonly IProductRepository _productsRepository;
//     private readonly IUserRepository _userRepository;
//     private readonly IMapper _mapper;

//     public GetProductsByUserIdRequestHandler(IProductRepository productsRepository, IUserRepository userRepository, IMapper mapper)
//     {
//         _productsRepository = productsRepository;
//         _userRepository = userRepository;
//         _mapper = mapper;
//     }

//     public async Task<List<ProductDto>> Handle(GetProductsByUserIdRequest request, CancellationToken token)
//     {
//         var user = await _userRepository.Get(request.UserId);
//         if (user == null)
//             throw new NotFoundException(nameof(User), request.UserId);

//         var products = await _productsRepository.Get(request.UserId);
//         return _mapper.Map<List<ProductDto>>(products);
//     }
// }