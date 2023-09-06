using Application.DTOs.Catergories;
using Application.Features.Categories.Request.Queries;
using ErrorOr;
using MediatR;
using Domain.Errors;
using Application.Contracts;
using AutoMapper;

namespace Application.Features.Categories.Handler.Queries
{
    public class GetCategoryRequestHandler : IRequestHandler<GetCategoryRequest, ErrorOr<CategoryResponseDto>>
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetCategoryRequestHandler(ICategoryRepository categoryRepository, IUserRepository userRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<CategoryResponseDto>> Handle(GetCategoryRequest request, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetUserById(request.UserId);

            // check if user exists
            if (user == null)
            {
                return Errors.User.UserNotFound;
            }

            var category = await _categoryRepository.GetCategoryById(request.CategoryId);

            return _mapper.Map<CategoryResponseDto>(category);
        }
    }
}