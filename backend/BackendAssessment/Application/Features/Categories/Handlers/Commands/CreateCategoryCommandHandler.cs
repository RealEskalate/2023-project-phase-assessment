using Application.Contracts.Persistence;
using Application.DTOs.Category.validators;
using Application.Exceptions;
using Application.Features.Categories.Requests.Commands;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Handlers.Commands;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, BaseCommandResponse<Category>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<BaseCommandResponse<Category>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse<Category>();
        
        var validator = new CreateCategoryDtoValidator(_unitOfWork);
        var validationResult = await validator.ValidateAsync(request.CategoryDto, cancellationToken);
        
        if (validationResult.IsValid == false)
        {
            throw new ValidationException(validationResult);
        }
        
        var category = _mapper.Map<Category>(request.CategoryDto);
        await _unitOfWork.CategoryRepository.Add(category);
        await _unitOfWork.Save();
        
        return BaseCommandResponse<Category>.SuccessHandler(category);
    }
    
}