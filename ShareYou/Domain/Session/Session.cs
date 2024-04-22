namespace ShareYou.Domain.Session;

public sealed class Session
{

    public string SessionConnectionID { get; set; }
    public string HubGroupID { get; set; }
    public List<UserConnection> ConnectedUsers { get; set; } = new();
    public List<UserConnection> PendingUsers { get; set; } = new();
    public int MaxUsers { get; set; }
    public int CurrentNumberOfUsers => ConnectedUsers.Count;
    public object Changes { get; private init; } = new object();
    public bool HadChangesAfterSave { get; set; } = false;
    public Session(string sessionConnectionID)
    {
        SessionConnectionID = sessionConnectionID;
    }
}
