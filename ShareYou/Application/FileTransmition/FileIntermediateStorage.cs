using Ardalis.Result;
using Microsoft.Extensions.Caching.Distributed;

namespace ShareYou.Application.FileTransmition;

public class FileIntermediateStorage : IFileIntermediateStorage
{
    public Task<Result<FileCache>> RetrieveFileAsync(string fileId)
    {
        throw new NotImplementedException();
    }

    public Task<Result<string>> StoreFileAsync(FileCache file)
    {
        throw new NotImplementedException();
    }
}

