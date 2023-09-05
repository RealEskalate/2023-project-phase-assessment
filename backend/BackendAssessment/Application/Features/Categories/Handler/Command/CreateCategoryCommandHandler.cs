using Application.DTOs.Category;
using Application.Features.Categories.Request.Command;
using MediatR;
using Application.Persistence.Contracts;
using AutoMapper;
using Domain.Entites;

namespace Application.Features.Categories.Handler.Command
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryDto>
    {
        public IMapper _mapper;
        public ICategoryRepository _categoryRepository;

        public CreateCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var newCategory = _mapper.Map<Category>(request.categoryDTO);

            await _categoryRepository.Add(newCategory);
            var createdCategoryDTO = _mapper.Map<CategoryDto>(newCategory);

            return createdCategoryDTO;
        }
    }
}