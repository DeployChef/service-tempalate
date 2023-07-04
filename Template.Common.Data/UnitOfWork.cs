using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Template.Common.Data.Interfaces;

namespace Template.Common.Data;

public class UnitOfWork<T> : IUnitOfWork where T : DbContext
{
    private readonly T _dbContext;

    public UnitOfWork(T dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken)
        => _dbContext.Database.BeginTransactionAsync(cancellationToken);

    public Task<IDbContextTransaction> BeginTransactionAsync(IsolationLevel isolationLevel, CancellationToken cancellationToken)
        => _dbContext.Database.BeginTransactionAsync(isolationLevel, cancellationToken);

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        var now = DateTime.UtcNow;

        foreach (var changedEntity in _dbContext.ChangeTracker.Entries())
        {
            if (changedEntity.Entity is Entity entity)
            {
                switch (changedEntity.State)
                {
                    case EntityState.Added:
                        entity.CreatedAt = now;
                        entity.UpdatedAt = now;
                        break;

                    case EntityState.Modified:
                        entity.UpdatedAt = now;
                        break;
                }
            }
        }

        return _dbContext.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}