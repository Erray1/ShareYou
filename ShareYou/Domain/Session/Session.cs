namespace ShareYou.Domain.Session;

public sealed class Session
{
    public string SessionConnectionID { get; set; }
    public List<UserConnection> ConnectedUsers { get; set; } = new();
    public List<UserConnection> PendingUsers { get; set; } = new();
    public int MaxUsers { get; set; }
    
    public byte[] Data { get; set; }
    public Session(string sessionConnectionID)
    {
        SessionConnectionID = sessionConnectionID;
    }
}
