using System.ComponentModel.DataAnnotations.Schema;
using ShareYou.Domain.Entities.Nested;
using ShareYou.Domain.WhiteboardData;

namespace ShareYou.Domain.Entities;

public sealed class WhiteboardMetadata
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string ID { get; set; }
    public string HostID { get; init; } = string.Empty;
    public string Name { get; set; }
    public List<UserStatusForWhiteboard> InvitedUsers { get; init; } = new();
    public int MaxConnections { get; set; }
    public WhiteboardAccess AccessStatus { get; set; }
    public WhiteboardType WhiteboardType { get; init; }
    public DateOnly DateCreated { get; init; }
    public int? LifetimeDays { get; set; }
    public bool IsDeleted { get; set; }
}
