using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Template.Common.Data.Interfaces;

namespace Template.Common.Data;

public abstract class Repository<TContext, T> : IRepository<T>
    where TContext : DbContext
    where T : Entity
{
    private readonly TContext _dbContext;
    private readonly DbSet<T> _entities;

    protected Repository(TContext context)
    {
        _dbContext = context;
        _entities = context.Set<T>();
    }

    public virtual async Task<IReadOnlyCollection<T>> GetAllAsync(CancellationToken cancellationToken)
        => await _entities.ToListAsync(cancellationToken);

    public virtual async Task<IReadOnlyCollection<T>> GetPageAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
        => await _entities
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

    public virtual async Task<T?> GetByIdAsync(long id, CancellationToken cancellationToken)
        => await _entities.FindAsync(new object[] {id}, cancellationToken);

    public virtual async Task<IReadOnlyCollection<T>> GetByIdsAsync(IReadOnlyCollection<long> ids, CancellationToken cancellationToken)
        => await _entities.Where(i => ids.Contains(i.Id)).ToListAsync(cancellationToken);

    public virtual async Task InsertAsync(T entity, CancellationToken cancellationToken)
        => await _entities.AddAsync(entity, cancellationToken);

    public async Task InsertAsync(IEnumerable<T> entities, CancellationToken cancellationToken)
    {
        await _entities.AddRangeAsync(entities, cancellationToken);
    }

    public virtual async Task<bool> InsertIfNotExistsAsync(T entity, Expression<Func<T, bool>>? predicate, CancellationToken cancellationToken)
    {
        var existsTask = predicate != null ? _entities.AnyAsync(predicate, cancellationToken) : _entities.AnyAsync(cancellationToken);
        var exists = await existsTask;

        if (!exists)
            await _entities.AddAsync(entity, cancellationToken);

        return !exists;
    }

    public virtual Task UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        _entities.Attach(entity);
        var entry = _dbContext.Entry(entity);
        entry.State = EntityState.Modified;

        return Task.CompletedTask;
    }

    public virtual Task UpdateAsync(IReadOnlyCollection<T> entities, CancellationToken cancellationToken)
    {
        _entities.AttachRange(entities);
        foreach (var entity in entities)
        {
            var entry = _dbContext.Entry(entity);
            entry.State = EntityState.Modified;
        }

        return Task.CompletedTask;
    }

    public virtual Task RemoveAsync(T entity, CancellationToken cancellationToken)
    {
        _entities.Remove(entity);

        return Task.CompletedTask;
    }

    public virtual Task RemoveRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken)
    {
        _entities.RemoveRange(entities);

        return Task.CompletedTask;
    }

    public virtual async Task<bool> ExistsAsync(Expression<Func<T, bool>>? predicate, CancellationToken cancellationToken)
    {
        var existsTask = predicate != null ? _entities.AnyAsync(predicate, cancellationToken) : _entities.AnyAsync(cancellationToken);
        var exists = await existsTask;

        return exists;
    }

    public async Task<int> GetCountAsync(CancellationToken cancellationToken)
        => await _entities.CountAsync(cancellationToken);

    public virtual async Task<int> GetCountAsync(Expression<Func<T, bool>>? predicate, CancellationToken cancellationToken)
    {
        var countTask = predicate != null ? _entities.CountAsync(predicate, cancellationToken) : _entities.CountAsync(cancellationToken);
        var count = await countTask;

        return count;
    }
}