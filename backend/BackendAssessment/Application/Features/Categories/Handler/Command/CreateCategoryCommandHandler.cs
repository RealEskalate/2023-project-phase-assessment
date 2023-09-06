using Application.DTOs.Category;
using Application.Features.Categories.Request.Command;
using AutoMapper;
using MediatR;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entites;

namespace Application.Features.Categories.Handler.Command
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryRetriveDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository i, IMapper mapper)
        {
            _categoryRepository = i;
            _mapper = mapper;
        }

        public async Task<CategoryRetriveDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request);
            var result = await _categoryRepository.Add(category);

            var response = _mapper.Map<CategoryRetriveDto>(result);
            return response;
        }
    }
}

