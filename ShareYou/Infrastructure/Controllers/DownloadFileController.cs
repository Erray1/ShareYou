using Microsoft.AspNetCore.Mvc;

namespace ShareYou.Infrastructure.Controllers;

[ApiController]
[Route("api/{contoller}")]
public class DownloadFileController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> DownloadFile([FromQuery] string temporaryFileId)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }
}

