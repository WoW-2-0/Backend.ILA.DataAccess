namespace EfCore.AuditInterceptor.Domain.Brokers;

public interface IRequestUserContextProvider
{
    Guid GetUserIdAsync(CancellationToken cancellationToken = default);
}