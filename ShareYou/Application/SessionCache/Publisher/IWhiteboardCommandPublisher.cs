using ShareYou.Application.SessionCache.Commands;

namespace ShareYou.Application.SessionCache.Publisher;
public interface IWhiteboardCommandPublisher
{
    public Task SendCommand(string sessionId, IWhiteboardCommand command);
}

