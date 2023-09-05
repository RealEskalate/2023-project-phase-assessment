using Domain.Entities;

namespace Application.Contracts.Persistence;

public interface IUnitOfWork : IDisposable
{
    public IUserRepository UserRepository { get; }
    public IProductRepository ProductRepository { get; }
    public ICategoryRepository CategoryRepository { get; }
    public IBookingRepository BookingRepository { get; }

    public Task<int> Save();
    public void Detach(BaseEntity entity);
}