using Application.Contracts;
using Application.Exceptions;
using Application.Features.Category.Request.Commands;
using Application.Features.Product.Request.Commands;
using Application.Responses;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Handlers.Command;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, BaseCommandResponse<int>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;

    }

    public async Task<BaseCommandResponse<int>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var category = _mapper.Map<Domain.Entites.Category>(request.createCategory);
            await _unitOfWork.categoryRepository.Add(category);
            await _unitOfWork.Save();

            return BaseCommandResponse<int>.SuccessHandler(category.CategoryId);
        }catch (Exception ex)
        {
            return BaseCommandResponse<int>.FailureHandler(ex);
        }

        
    }
}