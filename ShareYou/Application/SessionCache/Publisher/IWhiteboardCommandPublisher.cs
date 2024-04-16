namespace ShareYou.Application.SessionCache.Publisher;

public interface IWhiteboardCommandPublisher
{
    public Task SendCommand(string sessionId, object command);
}

