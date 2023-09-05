using Application.Common.Responses;
using Application.Contracts.Persistence;
using Application.Features.Categories.Dtos;
using Application.Features.Categories.Queries.Requests;
using AutoMapper;
using MediatR;

namespace Application.Features.Categories.Handlers.Requests;

public class GetAllCategorysRequestHandler
    : IRequestHandler<GetAllCategoriesRequest, CommonResponse<List<CategoryDto>>>
{
    private IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllCategorysRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CommonResponse<List<CategoryDto>>> Handle(
        GetAllCategoriesRequest request,
        CancellationToken cancellationToken
    )
    {
        return CommonResponse<List<CategoryDto>>.Success(_mapper.Map<List<CategoryDto>>(await _unitOfWork.CategoryRepository.GetAsync()));
    }
}
