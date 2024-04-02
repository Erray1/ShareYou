using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShareYou.Infrastructure.DTO.Requests;

namespace ShareYou.Infrastructure.Controllers;

[Route("api/{controller}")]
[ApiController]
[Authorize]
public class WhiteboardsController : ControllerBase
{
    // Кэшировать на стороне клиента
    [HttpGet("get-all")]
    [AllowAnonymous]
    public async Task<IActionResult> GetWhiteboards()
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    [HttpGet("get-current-state/{whiteboardId}")]
    [AllowAnonymous]
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

