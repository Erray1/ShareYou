namespace ShareYou.Infrastructure.DTO.Requests;

public sealed class UploadFileRequest
{
    public string SessionID { get; set; }
    public string UserConnectionID { get; set; }
    public string FileName { get; set; }
    public string FileType { get; set; }
    public byte[] Data { get; set; }
    public List<string> UsersToShareWith {  get; set; }
}
