using EfCore.AuditInterceptor.Domain.Brokers;
using EfCore.AuditInterceptor.Domain.Constants;
using EfCore.AuditInterceptor.Infrastructure.Common.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace EfCore.AuditInterceptor.Infrastructure.Common.RequestContexts.Brokers;

public class RequestUserContextProvider(
    IHttpContextAccessor httpContextAccessor,
    IOptions<RequestUserContextSettings> requestUserContextSettings
) : IRequestUserContextProvider
{
    private readonly RequestUserContextSettings _requestUserContextSettings = requestUserContextSettings.Value;

    public Guid GetUserIdAsync(CancellationToken cancellationToken = default)
    {
        var httpContext = httpContextAccessor.HttpContext!;
        var userIdClaim = httpContext.User.Claims.FirstOrDefault(claim => claim.Type == ClaimConstants.UserId)?.Value;
        return userIdClaim is not null ? Guid.Parse(userIdClaim) : _requestUserContextSettings.SystemUserId;
    }
}