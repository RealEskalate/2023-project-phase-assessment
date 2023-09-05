using Application.Contracts;
using Application.Dto.Category;
using Application.Features.Category.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Handlers.Queries;

public class GetCategoriesRequestHandler : IRequestHandler<GetCategoriesRequest, IReadOnlyList<CategoryDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
        
    public GetCategoriesRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<IReadOnlyList<CategoryDto>> Handle(GetCategoriesRequest request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.CategoryRepository.GetAllAsync();
        return _mapper.Map<IReadOnlyList<CategoryDto>>(result);
    }
}