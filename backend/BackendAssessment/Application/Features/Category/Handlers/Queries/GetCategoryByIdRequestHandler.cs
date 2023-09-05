using Application.Contracts;
using Application.Dtos;
using Application.Exceptions;
using Application.Features.Cateogory.Requests;
using AutoMapper;
using Domain.Entities;
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


        var DoesExist = await _categoryRepository.ExistsAsync(request.Id);

        if (!DoesExist)
        {
            throw new NotFoundException(nameof(Category), request.Id);
        }
        
        var category = await _categoryRepository.GetByIdAsync(request.Id);

        return _mapper.Map<CategoryDto>(category);
    }
}