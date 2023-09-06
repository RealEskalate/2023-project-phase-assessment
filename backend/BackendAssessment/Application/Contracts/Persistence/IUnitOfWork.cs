namespace Application.Contracts.Persistence;

public interface IUnitOfWork : IDisposable {
  
    IProductRepository ProductRepository { get; }
     ICategoryRepository CategoryRepository { get; }

    Task SaveChangesAsync(CancellationToken cancellationToken = default);
  
}
