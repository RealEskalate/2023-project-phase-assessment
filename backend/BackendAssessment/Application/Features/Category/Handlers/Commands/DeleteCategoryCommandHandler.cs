using Application.Contracts;
using Application.Exceptions;
using Application.Features.Category.Request.Commands;
using Application.Responses;
using AutoMapper;
using Domain.Entites;
using MediatR;

namespace Application.Features.Post.Handlers.Command;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, BaseCommandResponse<Unit>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;

    }

    public async Task<BaseCommandResponse<Unit>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var category = await _unitOfWork.categoryRepository.Get(request.CategoryId);
            if (category == null) throw new NotFoundException(nameof(category), request.CategoryId);
            
            await _unitOfWork.categoryRepository.Delete(category);
            int affectedRows = await _unitOfWork.Save();
            if (affectedRows == 0) throw new ServerErrorException("Something Went Wrong");

            return BaseCommandResponse<Unit>.SuccessHandler(Unit.Value); ;
        }catch (Exception ex)
        {
            return BaseCommandResponse<Unit>.FailureHandler(ex);
        }
    }
}