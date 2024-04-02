namespace ShareYou.Infrastructure.DTO.Requests;

public class InviteToGroupRequest
{
    public string GroupId { get; set; }
    public List<string> UserIds { get; set;}
}