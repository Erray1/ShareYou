using Microsoft.AspNetCore.Identity;
using ShareYou.Domain.Entities.Nested;

namespace ShareYou.Domain.Entities;

public sealed class User : IdentityUser
{
    public List<string> UserWhiteboards { get; set; }
    public List<WorkGroup> UserGroups { get; set; }
    public WhiteboardsFolder WhiteboardsHierarchy { get; set; } = WhiteboardsFolder.BaseFolder();
}
