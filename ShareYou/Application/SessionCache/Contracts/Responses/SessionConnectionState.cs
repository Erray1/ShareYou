using ShareYou.Domain.WhiteboardData;

namespace ShareYou.Application.SessionCache.Contracts.Responses;

public record SessionConnectionState
{
    public bool CanJoin { get; init; }
    public string SessionID { get; init; } = string.Empty;
    public string UserConnectionID { get; init; } = string.Empty;
    public WhiteboardAccess AccessLevel { get; init; } = WhiteboardAccess.Closed;
    public string? ErrorMessage { get; init; }

    private SessionConnectionState() { }

    public static SessionConnectionState Error(string message)
    {
        return new()
        {
            CanJoin = false,
        };
    }
    public static SessionConnectionState Success(string sessionID, string userConnectionID, WhiteboardAccess accessLevel)
    {
        return new()
        {
            CanJoin = true,
            SessionID = sessionID,
            UserConnectionID = userConnectionID,
            AccessLevel = accessLevel
        };
    }
}


