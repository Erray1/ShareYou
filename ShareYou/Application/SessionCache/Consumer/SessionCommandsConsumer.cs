using MassTransit;
using ShareYou.Application.SessionCache.Contracts.Requests.Commands;

namespace ShareYou.Application.SessionCache.Consumer;

public sealed class SessionCommandsConsumer : IConsumer<SessionCommand>
{
    private readonly IServiceProvider _serviceProvider;
    public SessionCommandsConsumer(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task Consume(ConsumeContext<SessionCommand> context)
    {
        throw new NotImplementedException();
    }

    // Приватные методы для обработки каждой команды
}
