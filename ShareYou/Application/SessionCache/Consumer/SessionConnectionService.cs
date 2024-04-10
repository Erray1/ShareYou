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
        switch (context.Message.Command)
        {
            case SessionConnectionCommand.CheckSessionAccessibility:
                var accessibilityStatus = await _sessionsCache.IsSessionOpenForConnections(context.Message.SessionID);
                await context.Send(accessibilityStatus);
                break;
            case SessionConnectionCommand.AllowUserToConnect:
                var connectionState = await _sessionsCache.InitiateUserConnectionAsync(context.Message.SessionID, context.Message.UserID!);
                await context.Send(connectionState);
                break;
            case SessionConnectionCommand.InitiateSession | SessionConnectionCommand.AllowUserToConnect:
                var createdSuccesfuly = await _sessionsCache.OpenSessionAsync(context.Message.SessionID);
                if (!createdSuccesfuly) {
                    await context.Send(SessionConnectionState.Error("Ошибка при инициации сесиии. Попробуйте снова через пару минут"));
                }
                var connectionState_ = await _sessionsCache.InitiateUserConnectionAsync(context.Message.SessionID, context.Message.UserID!);
                await context.Send(connectionState_);
                break;
        }
    }
}

 