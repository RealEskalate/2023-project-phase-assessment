using Application.DTO.Category;
using Application.Features.Categories.Request.Command;
using MediatR;
using Application.Persistance.Contracts;
using AutoMapper;
using Domain.Entites;

namespace Application.Features.Categories.Handler.Command
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryDTO>
    {
        public IMapper _mapper;
        public ICategoryRepository _categoryRepository;

        public UpdateCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task<CategoryDTO> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryId = request.categoryDTO.Id;
            var category = await _categoryRepository.Get(categoryId);

            if (category == null)
            {
                throw new Exception($"Category with ID {categoryId} not found");
            }

            var newcat = _mapper.Map<Category>(category);
            await _categoryRepository.Update(newcat);

            var updatedCategoryDTO = _mapper.Map<CategoryDTO>(category);

            return updatedCategoryDTO;
        }
    }
}