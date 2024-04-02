using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShareYou.Infrastructure.DTO.Requests;

namespace ShareYou.Infrastructure.Controllers;

[Route("api/{controller}")]
[ApiController]
public class LinksController : ControllerBase
{
    [HttpGet("create")]
    public async Task<IActionResult> CreateLink(CreateLinkRequest request)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }
}
