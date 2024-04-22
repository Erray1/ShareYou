
namespace ShareYou.Application.SessionCache.Contracts.Requests;

public abstract class SessionConnectionRequest
{
    public required string SessionID { get; init; }
    public abstract Task Execute();
}
