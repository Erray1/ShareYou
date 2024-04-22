using MassTransit;
using ShareYou.Application.SessionCache.Contracts.Requests;

namespace ShareYou.Application.SessionCache.Consumer;
public class SessionConnectionService : IConsumer<SessionConnectionRequest>
{
    private ISessionCacheService _sessionsCache;
    private IServiceProvider _serviceProvider;
    public SessionConnectionService(ISessionCacheService sessionsCache, IServiceProvider serviceProvider)
    {
        _sessionsCache = sessionsCache;
        _serviceProvider = serviceProvider;
    }

    public async Task Consume(ConsumeContext<SessionConnectionRequest> context)
    {
        
    }
}

 