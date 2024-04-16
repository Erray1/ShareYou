using Microsoft.AspNetCore.SignalR;
namespace ShareYou.Infrastructure.Hubs;

public sealed class SessionHub : Hub
{
    public async Task SendCommand()
    {
        throw new NotImplementedException();
    }

    public async Task SendFile(object file)
    {
        throw new NotImplementedException();
    }
}
