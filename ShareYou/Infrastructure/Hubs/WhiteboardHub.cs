using Microsoft.AspNetCore.SignalR;
using ShareYou.Application.SessionCache.Commands;

namespace ShareYou.Infrastructure.Hubs;

public sealed class SessionHub : Hub
{
    public async Task SendCommand(IWhiteboardCommand command)
    {
        throw new NotImplementedException();
    }

    public async Task SendFile(object file)
    {
        throw new NotImplementedException();
    }
}
