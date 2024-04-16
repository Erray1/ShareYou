using MassTransit;
using ShareYou.Application.SessionCache.Contracts.Requests;
using ShareYou.Application.SessionCache.Contracts.Responses;
using ShareYou.Domain.Entities;

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
        var request = new AllowUserToJoinSessionRequest { SessionID = whiteboardId, UserID = userId };
        var response = await _requestClient.GetResponse<SessionConnectionState>(request);
        return response.Message;
    }

    public async Task<SessionAccessibilityStatus> CheckSessionAccessibility(string whiteboardId)
    {
        var request = new ChechSessionAccesibilityRequest { SessionID = whiteboardId };
        var response = await _requestClient.GetResponse<SessionAccessibilityStatus>(request);
        return response.Message;
    }

    public async Task<SessionConnectionState> InitiateSessionAndGetUserConnectionCridentials(string userId, string whiteboardId)
    {
        var request = new InitiateSessionRequest { SessionID = whiteboardId, UserID = userId };
        var response = await _requestClient.GetResponse<SessionConnectionState>(request);
        return response.Message;
    }
}
