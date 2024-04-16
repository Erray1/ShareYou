namespace ShareYou.Application.SessionCache.Contracts.Requests;

public abstract class SessionConnectionRequest
{
    public Guid ID { get; init; } = Guid.NewGuid();
    public required string SessionID { get; init; }
}
