namespace CleanApi.Domain.Common;

public interface ISoftDeletable
{
    bool IsDeleted { get; }
    void Delete();
}
