using Application.DTO.Category;
using Application.Features.Categories.Request.Query;
using Application.Persistance.Contracts;
using AutoMapper;
using MediatR;

namespace Application.Features.Categories.Handler.Query
{
    public class GetCategoryByIdRequestHandler : IRequestHandler<GetCategoryByIdRequest, CategoryDTO>
    {
        public IMapper _mapper;
        public ICategoryRepository _categoryRepository;

        public GetCategoryByIdRequestHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task<CategoryDTO> Handle(GetCategoryByIdRequest request, CancellationToken cancellationToken)
        {
            var product = await _categoryRepository.Get(request.Id);
            return _mapper.Map<CategoryDTO>(product);
        }
    }
}