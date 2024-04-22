using Ardalis.Result;

namespace ShareYou.Application.SessionCache;
public interface ISessionCacheSaver
{
    public Task<Result<bool>> SaveIfRequired(string sessionId);
}

