using Application.Contracts;
using Application.DTOs.Categorys.Validation;
using Application.Exceptions;
using Application.Features.Categorys.Requests.Command;
using AutoMapper;
using Domain.Entites;
using MediatR;

namespace Application.Features.Categorys.Handlers.Command
{
    public class UpdateCategoryRequestHandler : IRequestHandler<UpdateCategoryRequest, Unit>
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public UpdateCategoryRequestHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCategoryDtoValidator();

            var validationResult = await  validator.ValidateAsync(request.UpdateCategoryDto);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var category = _mapper.Map<Category>(request.UpdateCategoryDto);

            await _categoryRepository.Update(category);

            return Unit.Value;
        }
    }
}
