namespace CleanApi.Domain.Interfaces;

/// <summary>
/// Unit of Work pattern for coordinating repository operations and database transactions.
/// </summary>
public interface IUnitOfWork : IDisposable
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
