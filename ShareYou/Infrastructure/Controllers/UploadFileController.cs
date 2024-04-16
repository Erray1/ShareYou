using Ardalis.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShareYou.Application.FileTransmition;
using ShareYou.Infrastructure.DTO.Requests;

namespace ShareYou.Infrastructure.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Policy = "HasAccount")]
public class UploadFileController : ControllerBase
{
    private readonly IFileIntermediateStorage _fileIntermediateStorage;
    public UploadFileController(IFileIntermediateStorage fileIntermediateStorage)
    {
        _fileIntermediateStorage = fileIntermediateStorage;
    }

    [HttpPost]
    public async Task<IActionResult> UploadFile(UploadFileRequest request)
    {
        var fileCache = new FileCache()
        {
            FileName = request.FileName,
            FileType = request.FileType,
            Data = request.Data,
        };
        Result<string> result = await _fileIntermediateStorage.StoreFileAsync(fileCache).ConfigureAwait(false);
        if (!result.IsSuccess)
        {
            return BadRequest(result.Errors);
        }

        // Call hub and pass link to download

        return Accepted();
    }
}

