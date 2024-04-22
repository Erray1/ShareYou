using Microsoft.AspNetCore.Identity;
using ShareYou.Domain.Entities.Nested;

namespace ShareYou.Domain.Entities;

public sealed class User : IdentityUser
{
    public List<WorkGroup> UserGroups { get; set; }
    public WhiteboardsFolder WhiteboardsHierarchy { get; private init; } = WhiteboardsFolder.BaseFolder();
}
