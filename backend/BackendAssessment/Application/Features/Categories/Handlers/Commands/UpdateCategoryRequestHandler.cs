using Application.Contracts.Persistence;
using AutoMapper;
using BackendAssessment.Application.Contracts.Persistence;
using BackendAssessment.Application.DTOs.CategoryDtos;
using BackendAssessment.Application.DTOs.CategoryDtos.Validators;
using BackendAssessment.Application.Exceptions;
using BackendAssessment.Application.Features.Categories.Handlers.Commands;
using BackendAssessment.Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Handlers.Commands;

public class UpdateCategoryRequestHandler : IRequestHandler<UpdateCategoryRequest, CategoryDto>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCategoryRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CategoryDto> Handle(UpdateCategoryRequest request, CancellationToken token)
    {
        var validator = new CategoryDtoValidator();
        var validationResult = await validator.ValidateAsync(request.CategoryDto, token);
        if (validationResult.IsValid == false)
        { 
            throw new ValidationException(validationResult);
        }
         var oldCategory = await _unitOfWork.CategoryRepository.Get(request.Id);
         oldCategory.Name = request.CategoryDto.Name;
         await _unitOfWork.Save();
         return _mapper.Map<CategoryDto>(oldCategory);
    }



}