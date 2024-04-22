using Ardalis.Result;
using ShareYou.Application.SessionCache.Contracts.Responses;
using ShareYou.Application.SessionCache.SessionConnectionServices;
using ShareYou.Domain.Session;

namespace ShareYou.Application.SessionCache;
public class SessionCache : ISessionCacheService, ISessionConnectionValidator
{
    public Task<Result> OpenSessionAsync(string sessionId)
    {
        throw new NotImplementedException();
    }
    public Task<Result> CloseSessionIfEmptyAsync(string sessionId)
    {
        throw new NotImplementedException();
    }

    public Task<Result> CloseUserConnectionAsync(string sessionId, string userId)
    {
        throw new NotImplementedException();
    }

    public Task<SessionConnectionState> InitiateUserConnectionAsync(string sessionId, string userId)
    {
        throw new NotImplementedException();
    }

    public Task<SessionAccessibilityStatus> IsSessionOpenForConnections(string sessionId)
    {
        throw new NotImplementedException();
    }



    public Task<Session> RetrieveSessionDataAsync(string sessionId, bool refresh = true)
    {
        throw new NotImplementedException();
    }

    public Task<Result> ValidateConnection(string connectionId, string sessionId)
    {
        throw new NotImplementedException();
    }
}

