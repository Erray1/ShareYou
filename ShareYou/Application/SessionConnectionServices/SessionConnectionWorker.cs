
using ShareYou.Application.SessionCache;
using ShareYou.Application.SessionCache.Contracts.Responses;
using ShareYou.Application.SessionCache.Publisher;
using ShareYou.Domain.Services;

namespace ShareYou.Application.SessionConnectionServices;

public class SessionConnectionWorker : ISessionConnectionWorker
{
    private readonly ISessionConnectionEstablisher _connectionEstablisher;
    private readonly IWhiteboardsMetadataRepository _metadataRepo;
    private readonly IServiceProvider _serviceProvider;
    public SessionConnectionWorker(
        ISessionConnectionEstablisher connectionEstablisher,
        IWhiteboardsMetadataRepository metadataRepo,
        IServiceProvider serviceProvider
        )
    {
       _connectionEstablisher = connectionEstablisher;
        _metadataRepo = metadataRepo;
        _serviceProvider = serviceProvider;
    }

    public async Task<SessionConnectionState> GetSessionConnectionStateAsync(string whiteboardId, string userId)
    {
        var whiteboardAccessLevel = await _metadataRepo.GetWhiteboardAccessLevelForUserAsync(whiteboardId, userId);
        if (whiteboardAccessLevel == Domain.WhiteboardMetadata.WhiteboardAccess.Closed)
        {
            return SessionConnectionState.Error("Сессия закрыта для подключений");
        }
        var sessionStatus = await _connectionEstablisher.CheckSessionAccessibility(whiteboardId);
        if (!sessionStatus.IsOpen && sessionStatus.IsRunning)
        {
            return SessionConnectionState.Error(sessionStatus.ErrorMessage!);
        }
        
        if (!sessionStatus.IsRunning)
        {
            return await _connectionEstablisher.InitiateSessionAndGetUserConnectionCridentials(userId, whiteboardId);
        }
        return await _connectionEstablisher.AllowUserToConnect(userId, whiteboardId);
    }

}
