using ShareYou.Infrastructure.DTO.Requests;

namespace ShareYou.Application.FileTransmition;

public interface IFileIntermediateStorage
{
    public Task<bool> StoreFileAsync(FileCache file);
    public Task<FileCache> RetrieveFileAsync(string fileId);
}
