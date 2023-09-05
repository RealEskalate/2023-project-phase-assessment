using Application.DTOs.Category;
using Application.Features.Categories.Request.Queries;
using AutoMapper;
using MediatR;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Features.Categories.Handler.Queries
{
    public class GetCategoryRequestHandler : IRequestHandler<GetCategoryRequest, CategoryRetriveDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryRequestHandler(ICategoryRepository commentRepository, IMapper mapper)
        {
            _categoryRepository = commentRepository;
            _mapper = mapper;
        }




        public async Task<CategoryRetriveDto> Handle(GetCategoryRequest request, CancellationToken cancellationToken)
        {
            var res = await _categoryRepository.Get(request.id)!;

            if (res == null)
            {
                throw new Exception();
            }

            var categoryResponse = _mapper.Map<CategoryRetriveDto>(res);
            return categoryResponse;
        }   
        
          
    }

    
}
