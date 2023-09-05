// using System.Security.Cryptography.X509Certificates;
// using Application.Contracts.Persistence;
// using AutoMapper;
// using BackendAssessment.Application.Contracts.Persistence;
// using BackendAssessment.Application.DTOs.ProductDtos;
// using BackendAssessment.Application.Features.Products.Requests.Queries;
// using BackendAssessment.Domain.Entities;
// using MediatR;

// namespace Application.Features.Products.Handlers.Queries;

// public class GetProductsByTagRequestHandler : IRequestHandler<GetProductsByCategoryRequest, List<ProductDto>>
// {
//     private readonly IProductRepository _productRepository;
//     private readonly IBookingRepository _bookingRepository;
//     private readonly IMapper _mapper;

//     public GetProductsByTagRequestHandler(IProductRepository ProductRepository, IBookingRepository bookingRepository, IMapper mapper)
//     {
//         _productRepository = ProductRepository;
//         _bookingRepository = bookingRepository;
//         _mapper = mapper;
//     }

//     public async Task<List<ProductDto>> Handle(GetProductsByCategoryRequest request, CancellationToken cancellationToken)
//     {
//         var products = await _productRepository.GetAll(request.Category);
//         products.Select(x=>x.Id)
//     }

//     // public async Task<List<ProductContentDto>> Handle(GetProductsByTagRequest request, CancellationToken token)
//     // {
//     //     var Products = await _ProductRepository.GetByTag(request.Tag);
//     //     return _mapper.Map<List<ProductContentDto>>(Products);
//     // }
// }