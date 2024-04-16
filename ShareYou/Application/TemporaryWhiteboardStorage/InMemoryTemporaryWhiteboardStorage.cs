using Ardalis.Result;
using Microsoft.Extensions.Caching.Memory;

namespace ShareYou.Application.TemporaryWhiteboardStorage;
public class InMemoryTemporaryWhiteboardStorage : ITemporaryWhiteboardStorage
{
    private readonly IMemoryCache _memoryCache;
    public InMemoryTemporaryWhiteboardStorage(
        IMemoryCache memoryCache
        )
    {
        _memoryCache = memoryCache;
    }
    public Task<Result<object>> RetrieveAsync(string id)
    {
        var whiteboard = _memoryCache.Get(id);
        if (whiteboard is null)
        {
            return Task.FromResult(Result<object>.NotFound(null));
        }
        return Task.FromResult(Result<object>.Success(whiteboard));
    }

    public Task<Result> SaveAsync(string id, object whiteboardData)
    {
        var options = new MemoryCacheEntryOptions
        {
            SlidingExpiration = TimeSpan.FromSeconds(30),
            AbsoluteExpiration = DateTimeOffset.UtcNow.AddSeconds(60)
        };
        _memoryCache.Set(id, whiteboardData, options);
        return Task.FromResult(Result.Success());
    }
}

