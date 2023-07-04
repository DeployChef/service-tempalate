using System.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace Template.Common.Data.Interfaces;

public interface IUnitOfWork : IDisposable
{
    Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken);

    Task<IDbContextTransaction> BeginTransactionAsync(IsolationLevel isolationLevel, CancellationToken cancellationToken);

    Task SaveChangesAsync(CancellationToken cancellationToken);
}