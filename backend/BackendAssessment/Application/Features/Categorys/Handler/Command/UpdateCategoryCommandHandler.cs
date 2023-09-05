using Application.DTO.Categories;
using Application.DTO.Users;
using Application.Features.Categorys.Request.Command;
using Application.Persistance.Contracts;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categorys.Handler.Command
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryDto>
    {
        public ICatagoryRepository _catagoryRepository { get; set; }

        public IMapper _mapper { get; set; }

        public UpdateCategoryCommandHandler(ICatagoryRepository catagoryRepository, IMapper mapper)
        {
            _catagoryRepository = catagoryRepository;
            _mapper = mapper;

        }
        public async Task<CategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryId = request.categoryDto.Id;
            var category = await _catagoryRepository.GetById(categoryId);

            if (category == null)
                throw new Exception($"User with ID {categoryId} not found");

            _mapper.Map(request.categoryDto, category);
            await _catagoryRepository.Update(category);

            return _mapper.Map<CategoryDto>(category);
        }
    }
}
