using AutoMapper;
using MediatR;
using ProductHub.Application.Common.Responses;
using ProductHub.Application.Contracts.Persistence;
using ProductHub.Application.Features.Categories.Requests.Commands;
using ProductHub.Domain.Entites;

namespace ProductHub.Application.Features.Categories.Handlers.Commands;

public class CreateCategoryCommandRequestHandler : IRequestHandler<CreateCategoryCommand, CommonResponse<int>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateCategoryCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CommonResponse<int>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken){
        //remember to add validation
        var category = _mapper.Map<Category>(request.CategoryCreateDto);
        category = await _unitOfWork.CategoryRepository.AddAsync(category);

        if( await _unitOfWork.SaveAsync() == 0)
        {
            return CommonResponse<int>.Failure("Error While Saving Changes!");
        
        }

        return CommonResponse<int>.Success(category.Id);
    }
}
