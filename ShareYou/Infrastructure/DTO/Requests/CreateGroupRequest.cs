using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShareYou.Infrastructure.DTO.Requests;

public class CreateGroupRequest : ControllerBase
{
    public string Name { get; set; }
    public List<string> InvitedUsers { get; set; }
}
