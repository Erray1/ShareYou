using ShareYou.Domain.Services;
using ShareYou.Infrastructure.Database;

namespace ShareYou.Application.Repositories;

public class WhiteboardsRepository : IWhiteboardsRepository
{
    private readonly WhiteboardMetadataDbContext _dbContext;
    public WhiteboardsRepository(WhiteboardMetadataDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public Task<object> DeleteWhiteboard(string whiteboardId, string userRequestedId)
    {
        throw new NotImplementedException();
    }

    public Task<object> GetCurrentWhiteboardStateAsync(string whiteboardId)
    {
        throw new NotImplementedException();
    }

    public Task<List<object>> GetWhiteboardsForUserAsync(string userId)
    {

    }

    public Task<object> RenameWhiteboard(string whiteboardId, string userRequestedId, string newName)
    {
        throw new NotImplementedException();
    }
}
