using ShareYou.Domain.WhiteboardMetadata;

namespace ShareYou.Domain.Services;

public interface IWhiteboardsMetadataRepository
{
    public Task<WhiteboardAccess> GetWhiteboardAccessLevelForUserAsync(string whiteboardId, string userId);
}
