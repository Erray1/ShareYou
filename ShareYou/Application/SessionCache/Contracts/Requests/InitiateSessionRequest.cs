namespace ShareYou.Application.SessionCache.Contracts.Requests;
public class InitiateSessionRequest : SessionConnectionRequest
{
    public string UserID { get; init; }
}

