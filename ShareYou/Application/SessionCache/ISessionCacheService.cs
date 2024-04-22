using Ardalis.Result;
using ShareYou.Application.SessionCache.Contracts.Responses;
using ShareYou.Domain.Session;

namespace ShareYou.Application.SessionCache;

public interface ISessionCacheService
{
    public Task<Result<Session>> RetrieveSessionDataAsync(string sessionId, bool refresh = true);
    public Task<SessionAccessibilityStatus> IsSessionOpenForConnections(string sessionId);
    // add user to pending
    public Task<SessionConnectionState> InitiateUserConnectionAsync(string sessionId, string userId);
    public Task<Result> CloseUserConnectionAsync(string sessionId, string userId);
    public Task<Result> OpenSessionAsync(string sessionId);
    public Task<Result> CloseSessionIfEmptyAsync(string sessionId);
}

