using Ardalis.Result;
using ShareYou.Domain.Entities;
using ShareYou.Infrastructure.DTO.Requests;
using System.Text.RegularExpressions;

namespace ShareYou.Domain.Services;
public interface IGroupsRepository
{
    public Task<Result<List<WorkGroup>>> GetGroupsAsync(string userId);
    public Task<Result<WorkGroup>> GetGroupDataAsync(string groupId);
    public Task<Result> CreateGroupAsync(string groupName, string userRequestedId);
    public Task<Result> AddUserToGroupAsync(string groupId, string userId);
    public Task<Result> DeleteGroupAsync(string groupId, string userRequestedId);
}

