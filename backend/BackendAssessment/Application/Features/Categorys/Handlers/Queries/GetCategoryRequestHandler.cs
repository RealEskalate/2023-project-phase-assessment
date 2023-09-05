using Application.Contracts;
using Application.DTOs.Categorys;
using Application.Exceptions;
using Application.Features.Categorys.Requests.Queries;
using AutoMapper;
using Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categorys.Handlers.Queries
{
    public class GetCategoryRequestHandler : IRequestHandler<GetCategoryRequest, CategoryDetailsDto>
    {

        ICategoryRepository _categoryRepo;
        IMapper _mapper;

        public GetCategoryRequestHandler(ICategoryRepository categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }
 
        public async Task<CategoryDetailsDto> Handle(GetCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepo.Get(request.Id);

            if (category == null)
                throw new NotFoundException(nameof(Category), request.Id);


            return _mapper.Map<CategoryDetailsDto>(category);

        }
    }
}
  