
using Ardalis.Result;
using ShareYou.Application.TemporaryWhiteboardStorage;

namespace ShareYou.Application.SessionCache;
public class SessionCacheSaver : ISessionCacheSaver
{
    private readonly ITemporaryWhiteboardStorage _temporaryStorage;
    public SessionCacheSaver(ITemporaryWhiteboardStorage temporaryStorage)
    {
        _temporaryStorage = temporaryStorage;
    }

    public async Task<Result> SaveAsync(string id, object sessionCache)
    {
        var result = await _temporaryStorage.SaveAsync(id ,sessionCache).ConfigureAwait(false);
        return result;
    }
}

