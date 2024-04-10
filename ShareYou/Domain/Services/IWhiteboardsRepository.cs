namespace ShareYou.Domain.Services;

public interface IWhiteboardsRepository {
    public Task<List<object>> GetWhiteboardsOwnedByUserAsync(string userId);
    public Task<List<object>> GetWhiteboardsAccessableByUserAsync(string userId);
    public Task<object> GetCurrentWhiteboardStateAsync(string whiteboardId);
    public Task<object> DeleteWhiteboard(string whiteboardId, string userRequestedId);
    public Task<object> RenameWhiteboard(string whiteboardId, string userRequestedId, string newName);
}
