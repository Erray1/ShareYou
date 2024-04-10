using ShareYou.Application.SessionCache.Commands;
using System.Collections.Concurrent;

namespace ShareYou.Application.SessionCache;
public class SessionCommandsStack : IUnitOfWork
{
    private readonly ConcurrentBag<IWhiteboardCommand> _commands;
    public SessionCommandsStack()
    {
        _commands = new ConcurrentBag<IWhiteboardCommand>();
    }
    public Task<bool> AddCommandAsync(IWhiteboardCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<object> GetChangesAsync(bool refresh)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveCommandAsync(IWhiteboardCommand command)
    {
        throw new NotImplementedException();
    }
}

