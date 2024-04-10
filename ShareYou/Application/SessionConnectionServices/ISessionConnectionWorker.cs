using ShareYou.Application.SessionCache.Contracts.Responses;

namespace ShareYou.Application.SessionConnectionServices;

public interface ISessionConnectionWorker
{
    public Task<SessionConnectionState> GetSessionConnectionStateAsync(string whiteboardId, string userId);
}

