using ShareYou.Domain.Entities.Nested;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShareYou.Domain.Entities;
public sealed class WorkGroup
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string ID { get; set; }
    public string Name { get; set; }    
    public string HostID { get; set; }
    public List<User> UsersOfGroup { get; set; }
    public WhiteboardsFolder WhiteboardsHierarchy { get; init; } = WhiteboardsFolder.BaseFolder();
}

