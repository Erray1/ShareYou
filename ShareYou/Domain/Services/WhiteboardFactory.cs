using ShareYou.Domain.Entities;
using ShareYou.Domain.UserMetadata;
using ShareYou.Domain.WhiteboardData;

namespace ShareYou.Domain.Services;

public class WhiteboardFactory : IWhiteboardMetadataFactory
{
    private readonly Dictionary<UserTier, int> maxConnections;
    private readonly Dictionary<UserTier, int?> whiteboardLifetimeDays;
    public Whiteboard CreateNew(UserTier userTier, string hostId, WhiteboardType type = WhiteboardType.Draw)
    {
        var whiteboard = new Whiteboard()
        {
            //HostID = hostId,
            //AccessStatus = WhiteboardAccess.Closed,
            //WhiteboardType = type,
            //DateCreated = DateOnly.FromDateTime(DateTime.Now),
            //MaxConnections = maxConnections[userTier],
            //LifeTime = whiteboardLifetimeDays[userTier]
        };
        return whiteboard;
    }
    public WhiteboardFactory()
    {
        maxConnections = new()
        {
            {UserTier.Guest, 10 },
            {UserTier.Classic, 50},
            {UserTier.Pro, 250}
        };
        whiteboardLifetimeDays = new()
        {
            {UserTier.Guest, 14 },
            {UserTier.Classic, 90 },
            {UserTier.Pro, null}
        };
    }
}