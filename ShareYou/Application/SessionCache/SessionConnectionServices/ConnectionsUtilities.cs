using ShareYou.Application.SessionCache.Contracts.Responses;
using ShareYou.Domain.WhiteboardMetadata;

namespace ShareYou.Application.SessionCache.SessionConnectionServices;

public static class ConnectionsUtilities
{
    public static string GenerateSessionConnectionString(string baseAddress, string whiteboardId, SessionConnectionState connectionState)
    {
        return $"{baseAddress}/whiteboards/{whiteboardId}?sessionId={connectionState.SessionID}&userConnectionId={connectionState.UserConnectionID}&accessLevel={(int)connectionState.AccessLevel}";
    }
}