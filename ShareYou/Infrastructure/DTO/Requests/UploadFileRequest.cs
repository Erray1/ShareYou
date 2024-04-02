namespace ShareYou.Infrastructure.DTO.Requests;

public sealed class UploadFileRequest
{
    public string HubConnectionID { get; set; }
    public string FileName { get; set; }
    public string FileType { get; set; }
    public byte[] Data { get; set; }
}
