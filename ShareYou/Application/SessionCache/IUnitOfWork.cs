using ShareYou.Application.SessionCache.Commands;

namespace ShareYou.Application.SessionCache;
public interface IUnitOfWork
{
    public Task<bool> AddCommandAsync(IWhiteboardCommand command);
    public Task<bool> RemoveCommandAsync(IWhiteboardCommand command);
    public Task<object> GetChangesAsync(bool refresh);
}

