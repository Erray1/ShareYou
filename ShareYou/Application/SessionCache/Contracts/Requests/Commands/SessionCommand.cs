using Ardalis.Result;
using ShareYou.Application.SessionCache.Contracts.Requests.Commands.ExecuteContext;

namespace ShareYou.Application.SessionCache.Contracts.Requests.Commands;
public abstract class SessionCommand
{
    public Guid ID { get; init; }
    public abstract Task Execute(IExecuteCommandContext context);
}

