using MassTransit;
using ShareYou.Application.SessionCache.Contracts.Requests;
using ShareYou.Application.SessionCache.Contracts.Responses;

namespace ShareYou.Application.SessionCache.Publisher;

public class SessionConnectionEstablisher : ISessionConnectionEstablisher
{
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IRequestClient<SessionConnectionRequest> _requestClient;
    private readonly IServiceProvider _serviceProvider;
    public SessionConnectionEstablisher(
        IPublishEndpoint publishEndpoint,
        IRequestClient<SessionConnectionRequest> requestClient,
        IServiceProvider serviceProvider)
    {
        _publishEndpoint = publishEndpoint;
        _requestClient = requestClient;
        _serviceProvider = serviceProvider;
    }
    public async Task<SessionConnectionState> AllowUserToConnect(string userId, string whiteboardId)
    {
        var client = _serviceProvider.GetRequiredService<IRequestClient<SessionConnectionRequest>>();
        var request = SessionRequestContractsFactory.Connection.AllowUserToConnect(userId, whiteboardId);
        var response = await client.GetResponse<SessionConnectionState>(request);
        return response.Message;
    }

    public async Task<SessionAccessibilityStatus> CheckSessionAccessibility(string whiteboardId)
    {
        var client = _serviceProvider.GetRequiredService<IRequestClient<SessionAccessibilityStatus>>();
        var request = SessionRequestContractsFactory.Connection.CheckSessionAccessibility(whiteboardId);
        var response = await client.GetResponse<SessionAccessibilityStatus>(request);
        return response.Message;
    }

    public async Task<SessionConnectionState> InitiateSessionAndGetUserConnectionCridentials(string userId, string whiteboardId)
    {
        var client = _serviceProvider.GetRequiredService<IRequestClient<SessionConnectionRequest>>();
        var request = SessionRequestContractsFactory.Connection.InitiateSessionAndGetUserConnectionCridentials(userId, whiteboardId);
        var response = await client.GetResponse<SessionConnectionState>(request);
        return response.Message;
    }
}
