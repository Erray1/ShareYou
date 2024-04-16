namespace ShareYou.Application.SessionCache.Contracts.Requests;

public class AllowUserToJoinSessionRequest : SessionConnectionRequest
{
    public string UserID { get; init; }
}
