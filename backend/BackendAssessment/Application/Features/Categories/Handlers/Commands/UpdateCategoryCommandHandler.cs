using AutoMapper;
using MediatR;
using ProductHub.Application.Common.Responses;
using ProductHub.Application.Contracts.Persistence;
using ProductHub.Application.Features.Categories.Requests.Commands;

namespace Application.Features.Categories.Handlers.Commands;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CommonResponse<int>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CommonResponse<int>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken){
        
        var category = await _unitOfWork.CategoryRepository.GetAsync(request.CategoryUpdateDto.Id);

        if (category == null)
        {
           return CommonResponse<int>.Failure("Category Not Found");
        }

        _mapper.Map(request.CategoryUpdateDto, category);
        await _unitOfWork.CategoryRepository.UpdateAsync(category);
        await _unitOfWork.SaveAsync();

        return CommonResponse<int>.Success(category.Id);
    }
}
