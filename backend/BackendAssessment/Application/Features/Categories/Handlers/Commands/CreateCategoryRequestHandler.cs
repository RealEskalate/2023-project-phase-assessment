using BackendAssessment.Application.Common.Exceptions;
using Application.Contracts.Persistence;
using AutoMapper;
using BackendAssessment.Domain.Entities;
using MediatR;
using BackendAssessment.Application.Contracts.Persistence;
using BackendAssessment.Application.Features.Categories.Requests.Commands;
using BackendAssessment.Application.DTOs.CategoryDtos.Validators;

namespace BackendAssessment.Application.Features.Categories.Handlers.Commands;

public class CreateCategoryRequestHandler : IRequestHandler<CreateCategoryRequest, Category>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateCategoryRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Category> Handle(CreateCategoryRequest request, CancellationToken token)
    {
        var validator = new CategoryDtoValidator();
        var validationResult = await validator.ValidateAsync(request.CategoryDto, token);

        if (validationResult.IsValid == false)
            throw new ValidationException(validationResult);
        
        // Add the Category
        var Category =  await _unitOfWork.CategoryRepository.Add(_mapper.Map<Category>(request.CategoryDto));
        await _unitOfWork.Save();;
        return Category;
    }
}
