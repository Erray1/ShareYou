using Microsoft.AspNetCore.SignalR;
using ShareYou.Application.SessionCache;
using ShareYou.Application.SessionCache.Contracts.Responses;
using ShareYou.Infrastructure.Hubs;

namespace ShareYou.Application.SessionCache.SessionConnectionServices;
public class SessionConnectionEstablisher : ISessionConnectionEstablisher
{
    private readonly ISessionCacheService _cache;
    private readonly IServiceProvider _serviceProvider;
    public SessionConnectionEstablisher(
        ISessionCacheService cacheService,
        IServiceProvider serviceProvider)
    {
        _cache = cacheService;
        _serviceProvider = serviceProvider;
    }
    public async Task<SessionConnectionState> AllowUserToConnect(string userId, string whiteboardId)
    {
        return await _cache.InitiateUserConnectionAsync(userId, whiteboardId);
    }

    public async Task<SessionAccessibilityStatus> CheckSessionAccessibility(string whiteboardId)
    {
        return await _cache.IsSessionOpenForConnections(whiteboardId);
    }

    public async Task<SessionConnectionState> InitiateSessionAndGetUserConnectionCridentials(string userId, string whiteboardId)
    {
        var result = await _cache.OpenSessionAsync(whiteboardId);
        if (!result.IsSuccess) return SessionConnectionState.Error("Error opening session");
        return await _cache.InitiateUserConnectionAsync(whiteboardId, userId);

    }
}

