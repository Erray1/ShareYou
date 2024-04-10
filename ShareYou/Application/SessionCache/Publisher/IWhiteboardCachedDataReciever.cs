namespace ShareYou.Application.SessionCache.Publisher;
public interface IWhiteboardCachedDataReciever
{
    public Task<object> GetCachedDataAsync(string sessionId);
}

