namespace ShareYou.Infrastructure.WhiteboardStorage;

public sealed class DbWhiteboardStorage : IAsyncWhiteboardStorage
{
    private readonly WhiteboardDbContext _db;
    public DbWhiteboardStorage(WhiteboardDbContext db)
    {
        _db = db;
    }
    public object ApplyChangesAsync(string whiteboardId)
    {
        throw new NotImplementedException();
    }

    public object CreateEmptyAsync(string whiteboardId)
    {
        throw new NotImplementedException();
    }

    public object RetrieveAsync(string whiteboardId)
    {
        throw new NotImplementedException();
    }
}