using Application.Contracts;
using Application.Dtos;
using Application.Features.Cateogory.Requests;
using AutoMapper;
using MediatR;

namespace Application.Features.Cateogory.Handlers.Queries;


public class GetCategoryByIdRequestHandler : IRequestHandler<GetCategoryByIdRequest, CategoryDto?>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetCategoryByIdRequestHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CategoryDto?> Handle(GetCategoryByIdRequest request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.Id);
        if (category == null) return null;
        return _mapper.Map<CategoryDto>(category);
    }
}