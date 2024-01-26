using EfCore.AuditInterceptor.Application.Common.RequestContexts.Brokers;
using EfCore.AuditInterceptor.Application.Common.RequestContexts.Models;
using EfCore.AuditInterceptor.Domain.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;

namespace EfCore.AuditInterceptor.Infrastructure.Common.RequestContexts.Brokers;

public class RequestContextProvider(IHttpContextAccessor httpContextAccessor) : IRequestContextProvider
{
    public RequestContext GetRequestContext()
    {
        var httpContext = httpContextAccessor.HttpContext!;
        var userIdClaim = httpContext.User.Claims.FirstOrDefault(claim => claim.Type == ClaimConstants.UserId)?.Value;

        var requestContext = new RequestContext
        {
            UserId = userIdClaim is not null ? Guid.Parse(userIdClaim) : default,
            IpAddress = httpContext.Connection.RemoteIpAddress!.ToString(),
            UserAgent = httpContext.Request.Headers[HeaderNames.UserAgent].ToString()
        };

        return requestContext;
    }
}