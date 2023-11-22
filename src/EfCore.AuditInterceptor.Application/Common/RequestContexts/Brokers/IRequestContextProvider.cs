namespace EfCore.AuditInterceptor.Application.Common.RequestContexts.Brokers;

public interface IRequestContextProvider
{
    Models.RequestContext GetRequestContext();
}