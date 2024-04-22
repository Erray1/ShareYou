namespace ShareYou.Application.SessionCache.Consumer;

public sealed class SessionCommandsConsumer
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ISessionCacheService _sessionCache;
    private readonly ILogger<SessionCommandsConsumer> _logger;
    public SessionCommandsConsumer(
        IServiceProvider serviceProvider,
        ISessionCacheService sessionCache, 
        ILogger<SessionCommandsConsumer> logger)
    {
        _serviceProvider = serviceProvider;
        _sessionCache = sessionCache;
        _logger = logger;
    }

    // Приватные методы для обработки каждой команды
}
