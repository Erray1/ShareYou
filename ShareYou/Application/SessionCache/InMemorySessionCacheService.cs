using Microsoft.Extensions.Caching.Memory;
using ShareYou.Application.SessionCache.Commands;
using ShareYou.Application.SessionCache.Contracts.Responses;
using ShareYou.Domain.Session;
using System.Collections.Concurrent;

namespace ShareYou.Application.SessionCache;

public sealed class InMemorySessionCacheService : ISessionCacheService
{
    private readonly IMemoryCache _cache;
    public InMemorySessionCacheService(IMemoryCache cache)
    {
        _cache = cache;
    }

    public async Task<bool> AddCommandAsync(string whiteboardId, IWhiteboardCommand command)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> RemoveCommandAsync(string whiteboardId, IWhiteboardCommand command)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> CreateSessionAsync(string whiteboardId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> RemoveSessionAsync(string whiteboardId)
    {
        throw new NotImplementedException();
    }

    public async Task<SessionAccessibilityStatus> IsSessionOpenForConnections(string whiteboardId)
    {
        throw new NotImplementedException();
    }

    public async Task<SessionConnectionState> InitiateUserConnectionAsync(string whiteboardId, string userId)
    {
        throw new NotImplementedException();
    }

    public async Task<object> RetrieveSessionDataAsync(string whiteboardId, bool refresh = true)
    {
        throw new NotImplementedException();
    }
}

