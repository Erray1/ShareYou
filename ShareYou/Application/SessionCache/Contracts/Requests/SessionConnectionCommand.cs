namespace ShareYou.Application.SessionCache.Contracts.Requests;

[Flags]
public enum SessionConnectionCommand
{
    AllowUserToConnect = 1,
    CheckSessionAccessibility = 2,
    InitiateSession = 4,
}