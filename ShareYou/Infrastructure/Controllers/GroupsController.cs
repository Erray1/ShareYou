using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShareYou.Infrastructure.DTO.Requests;

namespace ShareYou.Infrastructure.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Policy = "HasAccount")]
public class GroupsController : ControllerBase
{
    [ResponseCache(CacheProfileName = "UserGroups", Duration = 6400 * 24,  Location = ResponseCacheLocation.Client)]
    [HttpGet("get-all")]
    public async Task<IActionResult> GetGroups()
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    [HttpGet("get-data/{groupId}")]
    public async Task<IActionResult> GetGroupData(string groupId)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    [HttpPost("create-new")]
    public async Task<IActionResult> CreateGroup(CreateGroupRequest request)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    [HttpPatch("join/{groupId}")]
    public async Task<IActionResult> JoinGroup(string groupId)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    [HttpPatch("invite/{groupId}")]
    public async Task<IActionResult> InviteUsersToGroup(InviteToGroupRequest request)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    [HttpDelete("delete/{groupId}")]
    public async Task<IActionResult> DeleteGroup(string groupId)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }
}
