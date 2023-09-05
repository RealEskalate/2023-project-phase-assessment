using Application.Contracts.Persistence;

namespace ProductHub.Application.Contracts.Persistence;


public interface IUnitOfWork : IDisposable
{
    IProductRepository ProductRepository { get; }
    ICategoryRepository CategoryRepository { get; }
    IUserRepository UserRepository {get;}

    Task<int> SaveAsync();
}
