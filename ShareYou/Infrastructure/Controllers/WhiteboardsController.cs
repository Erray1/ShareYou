using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShareYou.Domain.Services;
using ShareYou.Infrastructure.DTO.Requests;

namespace ShareYou.Infrastructure.Controllers;

[Route("api/{controller}")]
[ApiController]
[Authorize(Policy = "HasAccount")]
public class WhiteboardsController : ControllerBase
{
    private readonly IWhiteboardsRepository _repo;
    public WhiteboardsController(IWhiteboardsRepository repo)
    {
        _repo = repo;
    }

    [ResponseCache(CacheProfileName = "UserOwnedWhiteboards", Duration = 6400 * 24, Location = ResponseCacheLocation.Client)]
    [HttpGet("get-owned")]
    [Authorize(Policy = "IsAuthorized")]
    public async Task<IActionResult> GetOwnedWhiteboards()
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    [ResponseCache(CacheProfileName = "UserAccessableWhiteboards", Duration = 6400 * 24, Location = ResponseCacheLocation.Client)]
    [HttpGet("get-accessable")]
    public async Task<IActionResult> GetAccesableWhiteboards()
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    [HttpGet("get-current-state/{whiteboardId}")]
    [Authorize(Policy = "IsAuthorized")]
    public async Task<IActionResult> GetCurrentState(string whiteboardId)
    {
        // Возвращает сохранённую доску + все накопленные изменения в хабе
        return StatusCode(StatusCodes.Status501NotImplemented);
    }
    
    [HttpPatch("update-access/{whiteboardId}")]
    public async Task<IActionResult> UpdateWhiteboardAccess(string whiteboardId)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    [HttpPatch("rename/{whiteboardId}")]
    public async Task<IActionResult> RenameWhiteboard(string whiteboardId, [FromBody] RenameWhiteboardRequest request)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    [HttpDelete("delete/{whiteboardId}")]
    public async Task<IActionResult> DeleteWhiteboard(string whiteboardId)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }
}

