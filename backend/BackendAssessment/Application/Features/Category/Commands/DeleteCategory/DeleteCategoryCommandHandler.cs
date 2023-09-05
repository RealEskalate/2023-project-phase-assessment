using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Category.Commands.DeleteCategory;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            // get the category
            var category = await _unitOfWork.CategoryRepository.Get(request.Id);
            
            // check category is null
            if (category == null)
                throw new NotFoundException(nameof(Domain.Entites.Categories.Category), request.Id);
            
            // delete the category
            await _unitOfWork.CategoryRepository.Delete(category);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}
