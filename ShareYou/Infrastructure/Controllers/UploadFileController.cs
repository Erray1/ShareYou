using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShareYou.Infrastructure.DTO.Requests;

namespace ShareYou.Infrastructure.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Policy = "HasAccount")]
public class UploadFileController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> UploadFile(UploadFileRequest request)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }
}

