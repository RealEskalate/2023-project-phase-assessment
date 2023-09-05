using Application.Contracts.Persistence;
using Application.DTOs.Product.validators;
using Application.Exceptions;
using Application.Features.Products.Requests.Commands;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Handlers.Commands;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, BaseCommandResponse<Product>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<BaseCommandResponse<Product>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateProductDtoValidator(_unitOfWork);
        var validationResult = await validator.ValidateAsync(request.ProductDto);
        
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult);
        }
        
        var product = _mapper.Map<Product>(request.ProductDto);
        await _unitOfWork.ProductRepository.Add(product);
        await _unitOfWork.Save();
        
        return BaseCommandResponse<Product>.SuccessHandler(product);
    }
}