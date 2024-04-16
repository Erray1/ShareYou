using Ardalis.Result;

namespace ShareYou.Application.SessionCache;

public interface ISessionCacheSaver
{
    public Task<Result> SaveAsync(string id, object sessionCache);
}
