using Ardalis.Result;
using ShareYou.Domain.Entities;
using ShareYou.Domain.Services;
using ShareYou.Infrastructure.Database;

namespace ShareYou.Application.Repositories;
public class GroupsRepository : IGroupsRepository
{
    private readonly UsersDbContext _db;
    public GroupsRepository(UsersDbContext db)
    {
        _db = db;
    }
    public async Task<Result> CreateGroupAsync(string groupName, string userRequestedId)
    {
        var newGroup = new WorkGroup() { 
            HostID = userRequestedId,
            ID = Guid.NewGuid().ToString(),
            Name = groupName,
        };
        var host = await _db.Users.FindAsync(userRequestedId);
        await _db.WorkGroups.AddAsync(newGroup);
        host!.UserGroups.Add(newGroup);
        return await resultSave();
    }

    public async Task<Result> DeleteGroupAsync(string groupId, string userRequestedId)
    {
        var group = await _db.WorkGroups.FindAsync(groupId);
        if (group is null) return Result.NotFound($"Group with id {groupId} not found");
        _db.WorkGroups.Remove(group);
        return await resultSave();
    }

    public async Task<Result<WorkGroup>> GetGroupDataAsync(string groupId)
    {
        var group = await _db.WorkGroups.FindAsync(groupId);
        if (group is null) return Result.NotFound($"Group with id {groupId} not found");
        return group;
    }

    public async Task<Result<List<WorkGroup>>> GetGroupsAsync(string userId)
    {
        var user = await _db.Users.FindAsync(userId);
        if (user is null) return Result.NotFound($"User with id {userId} not found");
        return user.UserGroups;
    }

    public async Task<Result> AddUserToGroupAsync(string groupId, string userId)
    {
        var user = await _db.Users.FindAsync(userId);
        var group = await _db.WorkGroups.FindAsync(groupId);
        if (user is null) return Result.NotFound($"User with id {userId} not found");
        if (group is null) return Result.NotFound($"Group with id {groupId} not found");
        group.UsersOfGroup.Add(user);
        user.UserGroups.Add(group);
        return await resultSave();
    }

    private async Task<Result> resultSave()
    {
        int affected = await _db.SaveChangesAsync();
        return affected == 1 ? Result.Success() : Result.Error("Error updating users db");
    }
}

