using Ardalis.Result;
using ShareYou.Domain.Entities;
using ShareYou.Domain.Entities.Nested;
using ShareYou.Domain.UserMetadata;
using ShareYou.Domain.WhiteboardData;

namespace ShareYou.Domain.Services;

public interface IWhiteboardsMetadataRepository
{
    public Task<Result> CreateAsync(string whiteboardName, string hostId, UserTier user, WhiteboardType type = WhiteboardType.Draw);
    public Task<Result<List<WhiteboardMetadata>>> GetMultipleAsync(IEnumerable<string> whiteboardIds);
    public Task<Result<WhiteboardMetadata>> GetSingleAsync(string whiteboardId);
    public Task<Result> UpdateAccessForUsersAsync(string whiteboardId, List<UserStatusForWhiteboard> statuses);
    public Task<Result> UpdateGlobalAccessAsync(string whiteboardId, WhiteboardAccess access);
    public Task<Result> RenameAsync(string whiteboardId, string newName);
    public Task<Result> MarkAsDeletedAsync(string whiteboardId);
    public Task<Result> RestoreFromGarbageAsync(string whiteboardId);
    public Task<WhiteboardAccess> GetWhiteboardAccessLevelForUserAsync(string whiteboardId, string userId);
}
