using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Category.Commands.UpdateCategory;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCategoryCommandHandler(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCategoryDtoCommandValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            
            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Category", validationResult);

            // var leaveAllocation = await _leaveAllocationRepository.GetByIdAsync(request.Id);
            var category = await _unitOfWork.CategoryRepository.Get(request.Category.Id);
            //
            if (category is null)
                throw new NotFoundException(nameof(Category), request.Category.Id);
            
            _mapper.Map(request.Category, category);
            
            await _unitOfWork.CategoryRepository.Update(category);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}
