namespace Application.Contracts;

public interface IUnitOfWork
{
    IProductRepository ProductRepository { get; }
    ICategoryRepository CategoryRepository { get; }
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}