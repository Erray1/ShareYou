using Microsoft.AspNetCore.Mvc;

namespace ShareYou.Infrastructure.Controllers;

[ApiController]
[Route("api/{contoller}")]
public class DownloadFileController : ControllerBase
{
    [HttpGet("{temporaryFileId}")]
    public async Task<IActionResult> DownloadFile(string temporaryFileId)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }
}

