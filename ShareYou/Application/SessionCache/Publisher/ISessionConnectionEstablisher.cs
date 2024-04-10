using ShareYou.Application.SessionCache.Contracts.Responses;

namespace ShareYou.Application.SessionCache.Publisher;

public interface ISessionConnectionEstablisher
{
    public Task<SessionConnectionState> AllowUserToConnect(string userId, string whiteboardId);
    public Task<SessionAccessibilityStatus> CheckSessionAccessibility(string whiteboardId);
    public Task<SessionConnectionState> InitiateSessionAndGetUserConnectionCridentials(string userId, string whiteboardId);
}
