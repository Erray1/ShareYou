using ShareYou.Domain.Entities;
using ShareYou.Domain.UserMetadata;
using ShareYou.Domain.WhiteboardData;

namespace ShareYou.Domain.Services;
public interface IWhiteboardMetadataFactory
{
    public WhiteboardMetadata CreateNew(string whiteboardId, string whiteboardName, string hostId, UserTier userTier, WhiteboardType type = WhiteboardType.Draw);
}