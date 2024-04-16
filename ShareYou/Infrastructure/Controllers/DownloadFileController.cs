using Microsoft.AspNetCore.Mvc;
using ShareYou.Application.FileTransmition;

namespace ShareYou.Infrastructure.Controllers;

[ApiController]
[Route("api/{contoller}")]
public class DownloadFileController : ControllerBase
{
    private readonly IFileIntermediateStorage _fileIntermediateStorage;
    public DownloadFileController(IFileIntermediateStorage fileIntermediateStorage)
    {
        _fileIntermediateStorage = fileIntermediateStorage;
    }

    [HttpGet("{temporaryFileId}")]
    public async Task<IActionResult> DownloadFile(string temporaryFileId)
    {
        var result = await _fileIntermediateStorage.RetrieveFileAsync(temporaryFileId).ConfigureAwait(false);
        if (!result.IsSuccess) return NotFound(result.Errors);
        var fileCache = (FileCache)result.GetValue();

        return File(fileCache.Data, fileCache.FileType, fileCache.FileName);
    }
}

