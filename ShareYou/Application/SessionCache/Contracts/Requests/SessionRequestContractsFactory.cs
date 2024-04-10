namespace ShareYou.Application.SessionCache.Contracts.Requests;

public static class SessionRequestContractsFactory
{
    public static class Connection
    {
        public static SessionConnectionRequest AllowUserToConnect(string userId, string sessionId)
        {
            return new()
            {
                SessionID = sessionId,
                UserID = userId,
                ID = Guid.NewGuid(), // ?
                Command = SessionConnectionCommand.AllowUserToConnect
            };
        }
        public static SessionConnectionRequest CheckSessionAccessibility(string sessionId)
        {
            return new()
            {
                SessionID = sessionId,
                ID = Guid.NewGuid(), // ?
                Command = SessionConnectionCommand.CheckSessionAccessibility
            };
        }
        public static SessionConnectionRequest InitiateSessionAndGetUserConnectionCridentials(string userId, string sessionId)
        {
            return new()
            {
                SessionID = sessionId,
                ID = Guid.NewGuid(), // ?
                UserID = userId,
                Command = SessionConnectionCommand.InitiateSession | SessionConnectionCommand.AllowUserToConnect
            };
        }
    }
}