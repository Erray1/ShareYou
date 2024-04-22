using ShareYou.Application.SessionCache.Contracts.Responses;

namespace ShareYou.Application.SessionCache.SessionConnectionServices;

public interface ISessionConnectionWorker
{
    public Task<SessionConnectionState> GetSessionConnectionStateAsync(string whiteboardId, string userId);
}

