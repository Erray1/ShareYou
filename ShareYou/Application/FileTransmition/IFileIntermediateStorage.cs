using Ardalis.Result;
using ShareYou.Infrastructure.DTO.Requests;

namespace ShareYou.Application.FileTransmition;

public interface IFileIntermediateStorage
{
    public Task<Result<string>> StoreFileAsync(FileCache file);
    public Task<Result<FileCache>> RetrieveFileAsync(string fileId);
}
