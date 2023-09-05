using Application.DTO.Categories;
using Application.Features.Categorys.Request.Command;
using Application.Persistance.Contracts;
using AutoMapper;
using Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categorys.Handler.Command
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryDto>
    {
        public ICatagoryRepository _catagoryRepository { get; set; }

        public IMapper _mapper { get; set; }

        public CreateCategoryCommandHandler(ICatagoryRepository catagoryRepository, IMapper mapper)
        {
            _catagoryRepository = catagoryRepository;
            _mapper = mapper;

        }
        public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request.categoryDto);

            category = await _catagoryRepository.Add(category);

            return _mapper.Map<CategoryDto>(category);
        }
    }
}
