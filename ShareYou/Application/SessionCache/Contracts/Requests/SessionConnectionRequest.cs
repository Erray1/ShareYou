namespace ShareYou.Application.SessionCache.Contracts.Requests;

public record SessionConnectionRequest
{
    public Guid ID { get; init; }
    public required string SessionID { get; init; }
    public string? UserID { get; init; }
    public SessionConnectionCommand Command { get; init; }
}
