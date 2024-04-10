using ShareYou.Application.SessionCache.Commands;
using ShareYou.Application.SessionCache.Contracts.Responses;

namespace ShareYou.Application.SessionCache;

public interface ISessionCacheService
{
    public Task<bool> AddCommandAsync(string whiteboardId, IWhiteboardCommand command);
    public Task<bool> RemoveCommandAsync(string whiteboardId, IWhiteboardCommand command);
    public Task<object> RetrieveSessionDataAsync(string whiteboardId, bool refresh = true);
    public Task<SessionAccessibilityStatus> IsSessionOpenForConnections(string whiteboardId);
    // add user to pending
    public Task<SessionConnectionState> InitiateUserConnectionAsync(string whiteboardId, string userId);
    public Task<bool> OpenSessionAsync(string whiteboardId);
    public Task<bool> CloseSessionAsync(string whiteboardId);
    
}

