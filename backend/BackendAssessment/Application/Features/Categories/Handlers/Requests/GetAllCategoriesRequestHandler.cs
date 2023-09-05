using AutoMapper;
using MediatR;
using ProductHub.Application.Common.Responses;
using ProductHub.Application.Contracts.Persistence;
using ProductHub.Application.DTOs.CategoryDtos;
using ProductHub.Application.Features.Categories.Requests.Queries;

namespace ProductHub.Application.Features.Categories.Handlers.Requests;

public class GetAllCategoriesRequestHandler : IRequestHandler<GetAllCategoriesRequest, CommonResponse<List<CategoryDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllCategoriesRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CommonResponse<List<CategoryDto>>> Handle(
        GetAllCategoriesRequest request,
        CancellationToken cancellationToken
    )
    {

        var categories = await _unitOfWork.CategoryRepository.GetAsync();
        // Handle null case
        if(categories == null)
        {
            CommonResponse<List<CategoryDto>>.Failure("Categories Not Found");
        }

        return CommonResponse<List<CategoryDto>>.Success(_mapper.Map<List<CategoryDto>>(categories));
    }
}
