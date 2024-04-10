using Microsoft.Extensions.Caching.Distributed;

namespace ShareYou.Application.FileTransmition;

public class FileIntermediateStorage : IFileIntermediateStorage, IDistributedCache
{
    public async Task<bool> StoreFileAsync(FileCache file)
    {
        throw new NotImplementedException();
    }
    public async Task<FileCache> RetrieveFileAsync(string fileId)
    {
        throw new NotImplementedException();
    }

    public byte[]? Get(string key)
    {
        throw new NotImplementedException();
    }

    public Task<byte[]?> GetAsync(string key, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public void Refresh(string key)
    {
        throw new NotImplementedException();
    }

    public Task RefreshAsync(string key, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public void Remove(string key)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(string key, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public void Set(string key, byte[] value, DistributedCacheEntryOptions options)
    {
        throw new NotImplementedException();
    }

    public Task SetAsync(string key, byte[] value, DistributedCacheEntryOptions options, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }


}

