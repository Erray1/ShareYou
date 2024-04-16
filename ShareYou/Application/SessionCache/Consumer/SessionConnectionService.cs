using MassTransit;
using ShareYou.Application.SessionCache.Contracts.Requests;
using ShareYou.Application.SessionCache.Contracts.Responses;

namespace ShareYou.Application.SessionCache.Consumer;
public class SessionConnectionService : IConsumer<SessionConnectionRequest>
{
    private ISessionCacheService _sessionsCache;
    public SessionConnectionService(ISessionCacheService sessionsCache)
    {
        _sessionsCache = sessionsCache;
    }

    public async Task Consume(ConsumeContext<SessionConnectionRequest> context)
    {
        
    }
}

 