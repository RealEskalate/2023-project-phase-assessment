using Application.Dtos;
using MediatR;

namespace Application.Features.User.Requests.Queries;

public class GetAllUsersRequest : IRequest<List<UserDto>>{}