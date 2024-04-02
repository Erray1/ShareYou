namespace ShareYou.Domain.Services;

public interface IWhiteboardRepository {
    public Task<List<object>> GetWhiteboardsForUserAsync(string userId);
    public Task<List<object>> GetGroupsForUserAsync(string userId);
    public Task<object> GetCurrentWhiteboardStateAsync(string whiteboardId);
    public Task<object> DeleteWhiteboard(string whiteboardId, string userRequestedId);
    public Task<object> RenameWhiteboard(string whiteboardId, string userRequestedId, string newName);
}
