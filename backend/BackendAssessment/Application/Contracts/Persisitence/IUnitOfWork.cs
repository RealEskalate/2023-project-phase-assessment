using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Contracts.Persisitence
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository ProductRepository { get; }
        ICatagoryRepository CatagoryRepository { get; }
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}