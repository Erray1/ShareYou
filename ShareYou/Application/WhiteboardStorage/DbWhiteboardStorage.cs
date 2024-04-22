using Ardalis.Result;
using Microsoft.EntityFrameworkCore;
using ShareYou.Domain.Entities;
using ShareYou.Infrastructure.WhiteboardStorage;

namespace ShareYou.Application.WhiteboardStorage;
public sealed class DbWhiteboardStorage : IWhiteboardStorage
{
    private readonly WhiteboardDbContext _dbContext;
    public DbWhiteboardStorage(WhiteboardDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<string>> CreateWhiteboard()
    {
        string id = Guid.NewGuid().ToString();
        var whiteboard = new Whiteboard() { ID = id };
        await _dbContext.Whiteboards.AddAsync(whiteboard);
        int affected = await _dbContext.SaveChangesAsync();
        if (affected == 0) return Result.Error("Error creating new whiteboard");
        return Result.Success(id);
    }

    public async Task<Result> DeleteWhiteboards(IEnumerable<string> whiteboardIds)
    {
        int rowsDeleted = await _dbContext.Whiteboards
            .IntersectBy(whiteboardIds, x => x.ID)
            .ExecuteDeleteAsync();
        return Result.Success();
    }

    public async Task<Result<object>> GetWhiteboardData(string whiteboardId)
    {
        var whiteboard = await _dbContext.Whiteboards.FindAsync(whiteboardId);
        if (whiteboard is null) return Result.Error("Whiteboard not found or was deleted");
        return Result.Success(whiteboard.Data);
    }

    public async Task<Result> ApplyCommands(string whiteboardId, object commands)
    {
        throw new NotImplementedException();
    }

}

