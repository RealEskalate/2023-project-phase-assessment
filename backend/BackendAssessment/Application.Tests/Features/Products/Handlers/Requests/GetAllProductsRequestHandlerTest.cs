using Application.Contracts.Persistence;
using Application.Features.Products.Dtos;
using Application.Features.Products.Handlers.Requests;
using Application.Features.Products.Queries.Requests;
using Application.Profiles;
using Application.Tests.Mocks;
using AutoMapper;
using Moq;
using Shouldly;

namespace Application.Tests.Features.Products.Handlers.Commands;

public class GetAllProductsRequestHandlerTest
{
    private readonly IMapper _mapper;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private GetAllProductsRequestHandler _handler;

    public GetAllProductsRequestHandlerTest()
    {
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });
        _mapper = mapperConfig.CreateMapper();
        _mockUnitOfWork = MockUnitOfWork.GetMockUnitOfWork();
        _handler = new GetAllProductsRequestHandler(_mockUnitOfWork.Object, _mapper);
    }

    [Fact]
    public async Task Valid_GetAllProductsRequest() {
      var validGetAllProductsRequest = new GetAllProductsRequest();

      var result = await _handler.Handle(validGetAllProductsRequest, CancellationToken.None);

      result.IsSuccess.ShouldBeTrue();
    }
}
