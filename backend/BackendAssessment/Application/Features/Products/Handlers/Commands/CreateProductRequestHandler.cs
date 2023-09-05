using BackendAssessment.Application.Common.Exceptions;
using Application.Contracts.Persistence;
using AutoMapper;
using BackendAssessment.Domain.Entities;
using MediatR;
using BackendAssessment.Application.Contracts.Persistence;
using BackendAssessment.Application.Features.Products.Requests.Commands;
using BackendAssessment.Application.DTOs.Products.Validators;

namespace BackendAssessment.Application.Features.Products.Handlers.Commands;

public class CreateProductRequestHandler : IRequestHandler<CreateProductRequest, Product>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateProductRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Product> Handle(CreateProductRequest request, CancellationToken token)
    {
        var validator = new ProductDtoValidator();
        var validationResult = await validator.ValidateAsync(request.ProductDto, token);

        if (validationResult.IsValid == false)
            throw new ValidationException(validationResult);
        
        // Add the Product
        var product =  await _unitOfWork.ProductRepository.Add(_mapper.Map<Product>(request.ProductDto));
        await _unitOfWork.Save();;
        return product;
    }
}
