namespace ShareYou.Infrastructure.WhiteboardStorage;
public interface IAsyncWhiteboardStorage
{
    // replace object with smth
    public object CreateEmptyAsync(string whiteboardId);
    public object ApplyChangesAsync(string whiteboardId, object data);
    public object RetrieveAsync(string whiteboardId);
}
