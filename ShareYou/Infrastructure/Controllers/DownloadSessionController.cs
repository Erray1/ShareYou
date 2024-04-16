using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShareYou.Application.TemporaryWhiteboardStorage;

namespace ShareYou.Infrastructure.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DownloadSessionController : ControllerBase
{
    private readonly ITemporaryWhiteboardStorage _temporaryWhiteboardStorage;
    public DownloadSessionController(ITemporaryWhiteboardStorage temporaryWhiteboardStorage)
    {
        _temporaryWhiteboardStorage = temporaryWhiteboardStorage;
    }

    [HttpGet]
    public async Task<IActionResult> DownloadWhiteboard(string temporaryId)
    {
        var result = await _temporaryWhiteboardStorage.RetrieveAsync(temporaryId);
        if (!result.IsSuccess)
        {
            return BadRequest(result.Errors.ToList());
        }
        return Ok(result.GetValue());
    }
}

