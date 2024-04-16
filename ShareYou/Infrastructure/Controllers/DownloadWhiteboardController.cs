using Microsoft.AspNetCore.Mvc;

namespace ShareYou.Infrastructure.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DownloadWhiteboardController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> DownloadWhiteboard(string whiteboardID)
    {
        throw new NotImplementedException();
    }
}

