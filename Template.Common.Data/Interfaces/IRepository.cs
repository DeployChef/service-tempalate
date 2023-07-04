using System.Linq.Expressions;

namespace Template.Common.Data.Interfaces;

public interface IRepository<T> where T : Entity
{
    Task<IReadOnlyCollection<T>> GetAllAsync(CancellationToken cancellationToken);

    Task<IReadOnlyCollection<T>> GetPageAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);

    Task<T?> GetByIdAsync(long id, CancellationToken cancellationToken);

    Task<IReadOnlyCollection<T>> GetByIdsAsync(IReadOnlyCollection<long> ids, CancellationToken cancellationToken);

    Task InsertAsync(T entity, CancellationToken cancellationToken);

    Task InsertAsync(IEnumerable<T> entities, CancellationToken cancellationToken);

    Task<bool> InsertIfNotExistsAsync(T entity, Expression<Func<T, bool>>? predicate, CancellationToken cancellationToken);

    Task UpdateAsync(T entity, CancellationToken cancellationToken);

    Task UpdateAsync(IReadOnlyCollection<T> entities, CancellationToken cancellationToken);

    Task RemoveAsync(T entity, CancellationToken cancellationToken);

    Task RemoveRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken);

    Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);

    Task<int> GetCountAsync(CancellationToken cancellationToken);

    Task<int> GetCountAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
}