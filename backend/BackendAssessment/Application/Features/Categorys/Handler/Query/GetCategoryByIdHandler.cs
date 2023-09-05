using Application.DTO.Categories;
using Application.DTO.Users;
using Application.Features.Categorys.Request.Query;
using Application.Persistance.Contracts;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categorys.Handler.Query
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
    {
        public ICatagoryRepository _catagoryRepository { get; set; }

        public IMapper _mapper { get; set; }

        public GetCategoryByIdHandler(ICatagoryRepository catagoryRepository, IMapper mapper)
        {
            _catagoryRepository = catagoryRepository;
            _mapper = mapper;
            
        }
        public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _catagoryRepository.GetById(request.Id);

            return _mapper.Map<CategoryDto>(category);
        }
    }
}
