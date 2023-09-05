using Application.Contracts.Identity;
using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Category.Commands.CreateCategory;
using Application.Responses;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public CreateCategoryCommandHandler(IMapper mapper,
            IUnitOfWork unitOfWork,
            IUserService userService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            this._userService = userService;
        }

        public async Task<BaseCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCategoryCommandValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            
            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Category", validationResult);

            var isAdmin = await _userService.IsAdmin();
            if (!isAdmin)
                throw new UnauthorizedAccessException("Not Authorized To Create Category");
            
            // create a category
            var category = _mapper.Map<Domain.Entites.Categories.Category>(request.Category);
            category.CreatedBy = _userService.UserId;
            
            // Add the category
            await _unitOfWork.CategoryRepository.Add(category);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            
            
            return new BaseCommandResponse()
            {
                Id = category.Id,
                Success = true,
                Message = "Category Created Successfully"
            };
        }
    }
}
