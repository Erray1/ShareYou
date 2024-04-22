using Ardalis.Result;

namespace ShareYou.Application.SessionCache.TemporaryStorageApi;
public interface ILoadWhiteboardToTemporaryStorageService
{
    public Task<Result> Execute(LoadDataToTemporaryStorageOptions options);
}
