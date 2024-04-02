using System.ComponentModel.DataAnnotations;

namespace ShareYou.Infrastructure.DTO.Requests;

public class RenameWhiteboardRequest
{
    [Length(1, 100)]
    public string? NewName { get; set; }
}