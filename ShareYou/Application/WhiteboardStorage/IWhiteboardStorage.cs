using Ardalis.Result;

namespace ShareYou.Application.WhiteboardStorage;
public interface IWhiteboardStorage
{
    public Task<Result<string>> CreateWhiteboard();
    public Task<Result> ApplyCommands(string whiteboardId, object commands);
    public Task<Result<object>> GetWhiteboardData(string whiteboardId);
    public Task<Result> DeleteWhiteboards(IEnumerable<string> whiteboardIds);
}

