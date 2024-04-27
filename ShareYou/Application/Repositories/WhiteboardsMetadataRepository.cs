using Ardalis.Result;
using Microsoft.EntityFrameworkCore;
using ShareYou.Domain.Entities;
using ShareYou.Domain.Entities.Nested;
using ShareYou.Domain.Services;
using ShareYou.Domain.UserMetadata;
using ShareYou.Domain.WhiteboardData;
using ShareYou.Infrastructure.Database;

namespace ShareYou.Application.Repositories;
public class WhiteboardsMetadataRepository : IWhiteboardsMetadataRepository
{
    private readonly WhiteboardMetadataDbContext _db;
    private readonly IServiceProvider _serviceProvider;
    public WhiteboardsMetadataRepository(
        WhiteboardMetadataDbContext db,
        IServiceProvider serviceProvider)
    {
        _db = db;   
        _serviceProvider = serviceProvider;
    }
    public async Task<Result> CreateAsync(string whiteboardName, string hostId, UserTier userTier, WhiteboardType type = WhiteboardType.Draw)
    {
        var factory = _serviceProvider.GetRequiredService<IWhiteboardMetadataFactory>();
        var id = Guid.NewGuid().ToString();
        var data = factory.CreateNew(id, whiteboardName, hostId, userTier, type);
        await _db.WhiteboardsMetadata.AddAsync(data);
        return await resultSave();
    }

    public async Task<Result<List<WhiteboardMetadata>>> GetMultipleAsync(IEnumerable<string> whiteboardIds)
    {
        var data = await _db.WhiteboardsMetadata
            .IntersectBy(whiteboardIds, x => x.ID)
            .ToListAsync();
        return Result.Success(data);
    }

    public async Task<Result<WhiteboardMetadata>> GetSingleAsync(string whiteboardId)
    {
        var metadata = await _db.WhiteboardsMetadata.FindAsync(whiteboardId);
        return metadata is null ? Result.NotFound() : Result.Success(metadata);
    }

    public async Task<WhiteboardAccess> GetWhiteboardAccessLevelForUserAsync(string whiteboardId, string userId)
    {
        var data = await _db.WhiteboardsMetadata.FindAsync(whiteboardId);
        if (data is null || data.AccessStatus == WhiteboardAccess.Closed) return WhiteboardAccess.Closed;
        var invitedAccess = data.InvitedUsers.FirstOrDefault(x => x.UserID == userId);
        if (invitedAccess is not null) return invitedAccess.AccessLevel;
        return data.AccessStatus;
    }

    public async Task<Result> MarkAsDeletedAsync(string whiteboardId)
    {
        var data = await _db.WhiteboardsMetadata.FindAsync(whiteboardId);
        if (data is null) return Result.NotFound();
        if (data.IsDeleted) return Result.Error($"Whiteboard with id ${whiteboardId} is already deleted");
        data.IsDeleted = true;
        return await resultSave();
    }

    public async Task<Result> RenameAsync(string whiteboardId, string newName)
    {
        var data = await _db.WhiteboardsMetadata.FindAsync(whiteboardId);
        if (data is null) return Result.NotFound();
        data.Name = newName;
        return await resultSave();
    }

    public async Task<Result> RestoreFromGarbageAsync(string whiteboardId)
    {
        var data = await _db.WhiteboardsMetadata.FindAsync(whiteboardId);
        if (data is null) return Result.NotFound();
        if (!data.IsDeleted) return Result.Error($"Whiteboard with id ${whiteboardId} was not deleted");
        return await resultSave();
    }

    public async Task<Result> UpdateAccessForUsersAsync(string whiteboardId, List<UserStatusForWhiteboard> statuses)
    {
        var data = await _db.WhiteboardsMetadata.FindAsync(whiteboardId);
        if (data is null) return Result.NotFound();
        var toUpdateExisting = data.InvitedUsers.Intersect(statuses);
        var toUpdateNew = statuses.Intersect(data.InvitedUsers);
        toUpdateExisting = toUpdateNew;

        var newStatuses = statuses.Except(data.InvitedUsers);
        data.InvitedUsers.AddRange(newStatuses);
        return await resultSave();
    }

    public async Task<Result> UpdateGlobalAccessAsync(string whiteboardId, WhiteboardAccess access)
    {
        var data = await _db.WhiteboardsMetadata.FindAsync(whiteboardId);
        if (data is null) return Result.NotFound();
        data.AccessStatus = access;
        return await resultSave();
    }
    private async Task<Result> resultSave()
    {
        int affected = await _db.SaveChangesAsync();
        return affected == 1 ? Result.Success() : Result.Error("Error updating metadata db");
    }
}

