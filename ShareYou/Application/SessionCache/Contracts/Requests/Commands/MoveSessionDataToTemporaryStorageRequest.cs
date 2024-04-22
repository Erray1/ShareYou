using Ardalis.Result;

namespace ShareYou.Application.SessionCache.Contracts.Requests.Commands;
public class MoveSessionDataToTemporaryStorageRequest : SessionCommand
{
    string? UserID { get; set; }
    string SessionID { get; set; }

    public override async Task<Result> Execute(ISessionCacheService sessionCache, IServiceProvider serviceProvider)
    {
        var cacheSaver = serviceProvider.GetRequiredService<ISessionCacheSaver>();
        var cache = await sessionCache.RetrieveSessionDataAsync(SessionID); 
        if (cache is null)
        {
            return Result.NotFound("Session data  not found");
        }
        return await cacheSaver.SaveAsync(SessionID, sessionCache);
    }
}

