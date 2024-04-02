using ShareYou.Infrastructure.DTO.Requests;

namespace ShareYou.Domain.Services;
public interface IGroupsRepository
{
    public Task<object> GetGroupsAsync(string userId);
    public Task<object> GetGroupDataAsync(string groupId);
    public Task<object> CreateGroupAsync(string groupName, string userRequestedId);
    public Task<object> JoinGroupAsync(string groupId, string userId);
    public Task<object> DeleteGroupAsync(string groupId, string userRequestedId);
}

