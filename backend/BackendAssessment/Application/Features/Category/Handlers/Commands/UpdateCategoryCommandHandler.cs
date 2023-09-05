using Application.Contracts;
using Application.Exceptions;
using Application.Features.Category.Request.Commands;
using Application.Responses;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Handlers.Command;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, BaseCommandResponse<Unit>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;

    }

    public async Task<BaseCommandResponse<Unit>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var category = await _unitOfWork.categoryRepository.Get(request.updatedCategory.CategoryId);
            _mapper.Map(request.updatedCategory, category);
            await _unitOfWork.categoryRepository.Update(category);

            return BaseCommandResponse<Unit>.SuccessHandler(Unit.Value); ;
        }catch (Exception ex)
        {
            return BaseCommandResponse<Unit>.FailureHandler(ex);
        }
    }

}