using Microsoft.AspNetCore.SignalR;
using ShareYou.Application.SessionCache;
using ShareYou.Application.SessionCache.SessionConnectionServices;
using ShareYou.Application.SessionCache.TemporaryStorageApi;
using System.Runtime.InteropServices;

namespace ShareYou.Infrastructure.Hubs;

public sealed class SessionHub : Hub
{
    private readonly IServiceProvider _serviceProvider;
    private readonly CancellationTokenSource _tokenSource;
    private readonly ILogger<SessionHub> _logger;
    private const string _groupHeaderName = "SessionID";
    private string? currentSessionID() {
        _request.Query.TryGetValue(_groupHeaderName, out var val);
        if (val.Count == 0) return null;
        return val.First()!.ToString();
    }
    private HttpRequest _request => Context.GetHttpContext()!.Request;
    public SessionHub(
        IServiceProvider serviceProvider,
        ILogger<SessionHub> logger,
        CancellationTokenSource tokenSource)
    {
        _serviceProvider = serviceProvider;
        _tokenSource = tokenSource;
        _logger = logger;
    }
    public async Task SendCommand()
    {
        throw new NotImplementedException();
    }

    public async Task SendFileLink(string callerId, string fileURL)
    {
        throw new NotImplementedException();
    }

    public override async Task OnConnectedAsync()
    {
        if (!_request.Query.ContainsKey(_groupHeaderName))
        {
            await Clients.Caller.SendAsync("OnInvalidConnection", "No session id in request header");
            Context.Abort();
        }
        await Clients.Caller.SendAsync("ValidateConnection");
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var cache = _serviceProvider.GetRequiredService<ISessionCacheService>();
        bool hasGroupId = _request.Query.TryGetValue(_groupHeaderName, out var value);
        if (!hasGroupId)
        {
            _logger.LogWarning("Session id was not found");
        }
        else
        {
            string groupdId = value.ElementAt(0)!;
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupdId);
            var resultUserAborted = await cache.CloseUserConnectionAsync(groupdId, Context.ConnectionId);
            var resultSessionClosed= await cache.CloseSessionIfEmptyAsync(groupdId);
            if (!resultSessionClosed.IsSuccess || !resultUserAborted.IsSuccess)
            {
                _logger.LogWarning(resultSessionClosed.Errors.Concat(resultUserAborted.Errors).Aggregate((prev, next) => String.Join("\n", prev, next)));
            }
        }
        await base.OnDisconnectedAsync(exception);
    }

    public async Task ValidateConnection(string sessionId)
    {
        var validator = _serviceProvider.GetRequiredService<ISessionConnectionValidator>();
        var validationResult = await validator.ValidateConnection(Context.ConnectionId, sessionId);
        if (!validationResult.IsSuccess)
        {
            await Clients.Caller.SendAsync("OnInvalidConnection", "Connection is not valid", _tokenSource.Token);
            Context.Abort();
        }

        await Groups.AddToGroupAsync(Context.ConnectionId, sessionId, _tokenSource.Token);
        await Clients.Caller.SendAsync("OnConnectionOpened", _tokenSource.Token);
        var saver = _serviceProvider.GetRequiredService<ILoadWhiteboardToTemporaryStorageService>();

        var cacheSendingResult = await saver.Execute(new() { SessionId = sessionId});

        if (cacheSendingResult.IsSuccess) await Clients.Caller.SendAsync("LoadData");
        else
        {
            _logger.LogWarning("Error sending cache to temporary storage");
        }
    }
}
