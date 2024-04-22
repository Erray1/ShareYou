using Ardalis.Result;

namespace ShareYou.Application.SessionCache.SessionConnectionServices;
public interface ISessionConnectionValidator
{
    public Task<Result> ValidateConnection(string connectionId, string sessionId);
}

