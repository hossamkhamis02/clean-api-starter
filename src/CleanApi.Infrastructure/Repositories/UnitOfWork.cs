using CleanApi.Domain.Interfaces;

namespace CleanApi.Infrastructure.Repositories;

/// <summary>
/// Unit of Work implementation wrapping the Entity Framework DbContext.
/// </summary>
public sealed class UnitOfWork : IUnitOfWork
{
    private readonly Data.ApplicationDbContext _context;

    public UnitOfWork(Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
