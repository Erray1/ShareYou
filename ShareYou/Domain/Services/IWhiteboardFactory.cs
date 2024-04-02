using ShareYou.Domain.Entities;
using ShareYou.Domain.UserMetadata;
using ShareYou.Domain.WhiteboardMetadata;

namespace ShareYou.Domain.Services;
public interface IWhiteboardFactory
{
    public Whiteboard CreateNew(UserTier userTier, string hostId, WhiteboardType type = WhiteboardType.Draw);
}