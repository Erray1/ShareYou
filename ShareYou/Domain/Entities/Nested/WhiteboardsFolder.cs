namespace ShareYou.Domain.Entities.Nested;
public class WhiteboardsFolder
{
    public string FolderName { get; set; }
    public List<string> NonStoredWhiteboardIds { get; set; } = new();

    public List<WhiteboardsFolder> Folders { get; set; } = new();
    private WhiteboardsFolder() { }
    private WhiteboardsFolder? parentFolder;
    public static WhiteboardsFolder BaseFolder()
    {
        return new WhiteboardsFolder()
        {
            FolderName = "BASE",
            NonStoredWhiteboardIds = new List<string>(),
            Folders = new List<WhiteboardsFolder>(),
            parentFolder = null
        };
    }
}

