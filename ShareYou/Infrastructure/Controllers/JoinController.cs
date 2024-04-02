using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShareYou.Infrastructure.Controllers;

// Здесь будет происходить валидацияя подключения
// и перенаправление на страницу с доской

[Route("api/[controller]")]
[ApiController]
public class JoinController : ControllerBase
{
    [HttpPost()]
    public async Task<IActionResult> JoinWhiteboard([FromQuery] string whiteboardID)
    {
        // return redirect to smwr
        return StatusCode(StatusCodes.Status501NotImplemented);
    }
}

