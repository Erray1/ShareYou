using Ardalis.Result;
using ShareYou.Domain.Session;

namespace ShareYou.Application.SessionCache;

public interface ISessionCacheSender
{
    public Task<Result> SendAsync(string sessionId, string destination);
}
