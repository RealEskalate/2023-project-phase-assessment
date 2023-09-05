using Application.Contracts;
using Application.Exceptions;
using Application.Features.Categorys.Requests.Command;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categorys.Handlers.Command
{
    public class DeleteCategoryRequestHandler : IRequestHandler<DeleteCategoryRequest, Unit>
    {

        private readonly ICategoryRepository _categoryRepository;
       
        public DeleteCategoryRequestHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            
        }
        public async Task<Unit> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.Get(request.Id);

            if (category == null)
            {
                throw new BadRequestException(" category not found ");

            }

            await _categoryRepository.Delete(category);

            return Unit.Value;
        }
    }
}
