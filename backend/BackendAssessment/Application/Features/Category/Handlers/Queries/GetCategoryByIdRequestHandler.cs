using Application.Contracts;
using Application.Dto.Category;
using Application.Features.Category.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Handlers.Queries;

public class GetCategoryByIdRequestHandler : IRequestHandler<GetCategoryByIdRequest, CategoryDto?>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
            
    public GetCategoryByIdRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<CategoryDto?> Handle(GetCategoryByIdRequest request, CancellationToken cancellationToken)
    {
        var result =  await _unitOfWork.CategoryRepository.GetByIdAsync(request.Id);
        return _mapper.Map<CategoryDto?>(result);
    }
}