using Ardalis.Result;
using ShareYou.Application.SessionCache.Utilities;
using ShareYou.Application.TemporaryWhiteboardStorage;
using ShareYou.Application.WhiteboardStorage;
using ShareYou.Domain.Session;
using System.Collections.Concurrent;

namespace ShareYou.Application.SessionCache.TemporaryStorageApi;
public class LoadWhiteboardToTemporaryStorageServiceV1 : ILoadWhiteboardToTemporaryStorageService
{
    private readonly ITemporaryWhiteboardStorage _temporaryStorage;
    private readonly IWhiteboardStorage _whiteboardStorage;
    private readonly ISessionCacheSaver _sessionCacheSaver;
    private readonly ILogger _logger;


    public LoadWhiteboardToTemporaryStorageServiceV1(
        ISessionCacheSaver cacheSaver,
        ITemporaryWhiteboardStorage temporaryWhiteboardStorage,
        IWhiteboardStorage whiteboardStorage,
        ILogger<LoadWhiteboardToTemporaryStorageServiceV1> logger
        )
    {
        _temporaryStorage = temporaryWhiteboardStorage; 
        _whiteboardStorage = whiteboardStorage;
        _logger = logger;
        _sessionCacheSaver = cacheSaver;
    }
    public async Task<Result> Execute(LoadDataToTemporaryStorageOptions options)
    {
        var resultSessionSaved = await _sessionCacheSaver.SaveIfRequired(options.SessionId);
        if (resultSessionSaved.Value)
        {
            var resultData = await _whiteboardStorage.GetWhiteboardData(options.SessionId);
            var resultTemporarySave = await _temporaryStorage.SaveAsync(options.SessionId, resultData.Value);
            if (!resultData.IsSuccess) _logger.LogError("Error retrieving data from storage");
            if (!resultTemporarySave.IsSuccess) _logger.LogError("Error saving data to temporary storage");
        }
      
        if (!resultSessionSaved.IsSuccess) _logger.LogError("Error saving session data");
        
        return Result.Success();
    }
}

