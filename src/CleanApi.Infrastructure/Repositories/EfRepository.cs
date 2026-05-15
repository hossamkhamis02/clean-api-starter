using CleanApi.Domain.Common;
using CleanApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CleanApi.Infrastructure.Repositories;

/// <summary>
/// Generic repository implementation using Entity Framework Core.
/// </summary>
/// <typeparam name="T">Entity type.</typeparam>
public sealed class EfRepository<T> : IRepository<T> where T : BaseEntity
{
    private readonly Data.ApplicationDbContext _context;
    private readonly DbSet<T> _dbSet;

    public EfRepository(Data.ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FindAsync([id], cancellationToken);
    }

    public async Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet.ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _dbSet.Where(predicate).ToListAsync(cancellationToken);
    }

    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
        return entity;
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    public Task<int> CountAsync(CancellationToken cancellationToken = default)
    {
        return _dbSet.CountAsync(cancellationToken);
    }
}
