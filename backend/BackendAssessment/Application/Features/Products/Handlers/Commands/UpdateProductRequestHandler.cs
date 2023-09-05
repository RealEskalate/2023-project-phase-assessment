using Application.Contracts.Persistence;
using AutoMapper;
using BackendAssessment.Application.Contracts.Persistence;
using BackendAssessment.Application.DTOs.CategoryDtos;
using BackendAssessment.Application.DTOs.ProductDtos;
using BackendAssessment.Application.DTOs.Products.Validators;
using BackendAssessment.Application.Exceptions;
using BackendAssessment.Application.Features.Products.Handlers.Commands;
using BackendAssessment.Domain.Entities;
using MediatR;

namespace Application.Features.Products.Handlers.Commands;

public class UpdateProductRequestHandler : IRequestHandler<UpdateProductRequest, ProductDto>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProductRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ProductDto> Handle(UpdateProductRequest request, CancellationToken token)
    {
        var validator = new ProductDtoValidator();
        var validationResult = await validator.ValidateAsync(request.ProductDto, token);
        if (validationResult.IsValid == false)
        { 
            throw new ValidationException(validationResult);
        }
         var oldProduct = await _unitOfWork.ProductRepository.Get(request.Id);
         oldProduct.Name = request.ProductDto.Name;
         oldProduct.Detail = request.ProductDto.Detail;
         oldProduct.Price = request.ProductDto.Price;
         oldProduct.Category = _mapper.Map<Category>(request.ProductDto.CategoryDto);
         oldProduct.Price = request.ProductDto.Price;
         await _unitOfWork.Save();
         return _mapper.Map<ProductDto>(oldProduct);
    }



}