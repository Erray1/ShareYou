namespace ShareYou.Application.SessionCache.Contracts.Responses;

public record SessionAccessibilityStatus
{
    public bool IsOpen { get; init; }
    public bool IsRunning { get; init; }
    public string? ErrorMessage { get; init; }
}
