using Ardalis.Result;

namespace ShareYou.Application.TemporaryWhiteboardStorage;

public interface ITemporaryWhiteboardStorage
{
    public Task<Result> SaveAsync(string id, object whiteboardData);
    public Task<Result<object>> RetrieveAsync(string id);
}
