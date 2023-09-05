using Application.Contracts.persistence;
using Application.Dtos.Category;
using Application.Features.Products.Request.Queries;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Handler.Queries
{

    public class GetCategoryDetailsRequestHandler : IRequestHandler<GetCategoryDetailsRequest, CategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public GetCategoryDetailsRequestHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(GetCategoryDetailsRequest request, CancellationToken cancellationToken)
        {
            var Category = await _categoryRepository.GetById(request.Id);
            return _mapper.Map<CategoryDto>(Category);
        }
    }
}
