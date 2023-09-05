using Application.Contracts.Persistence;
using Moq;

namespace Application.Tests.Mocks;

public class MockUnitOfWork
{
    public static Mock<IUnitOfWork> GetMockUnitOfWork()
    {
        var unitOfWork = new Mock<IUnitOfWork>();

        var mockUserRepository = MockUserRepository.GetMockUserRepository();
        var mockProductRepository = MockProductRepository.GetMockProductRepository();

        unitOfWork.Setup(uow => uow.UserRepository).Returns(mockUserRepository.Object);
        unitOfWork.Setup(uow => uow.ProductRepository).Returns(mockProductRepository.Object);
        unitOfWork.Setup(uow => uow.SaveAsync()).ReturnsAsync(1);
        return unitOfWork;
    }
}
