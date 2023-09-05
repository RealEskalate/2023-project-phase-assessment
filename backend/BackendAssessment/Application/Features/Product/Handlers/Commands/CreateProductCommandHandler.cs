using Application.Contracts;
using Application.Dtos.Product.Valiation;
using Application.Features.Prodcut.Requests.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Prodcut.Handlers.Commands;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IProductRepository _productRepository;

    private readonly IMapper _mapper;


    public CreateProductCommandHandler(IProductRepository productRepository,IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    
    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {  
       
        var product = _mapper.Map<Product>(request.CreateProductDto);
       await  _productRepository.AddAsync(product);
        return product.Id;
    }
}