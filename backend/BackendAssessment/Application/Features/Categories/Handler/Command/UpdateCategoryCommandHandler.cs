using Application.DTOs.Category;
using Application.Features.Categories.Request.Command;
using AutoMapper;
using Domain.Entites;
using MediatR;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Features.Categories.Handler.Command
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryRetriveDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryRepository i, IMapper mapper)
        {
            _categoryRepository = i;
            _mapper = mapper;
        }

        public async Task<CategoryRetriveDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.Get(request.id)!;
            if (category == null)
            {
                throw new Exception();
            }

            var categoryToUpdate = _mapper.Map(request, category );
            var updatedCategory = await _categoryRepository.Update(categoryToUpdate);
            return _mapper.Map<CategoryRetriveDto>(updatedCategory);
        }


    }
}
