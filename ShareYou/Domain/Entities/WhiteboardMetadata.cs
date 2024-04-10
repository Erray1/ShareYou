﻿using System.ComponentModel.DataAnnotations.Schema;
using ShareYou.Domain.Entities.Nested;
using ShareYou.Domain.WhiteboardMetadata;

namespace ShareYou.Domain.Entities;

public sealed class WhiteboardMetadata
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string ID { get; set; }
    public string HostID { get; init; } = string.Empty;
    public List<UserStatusForWhiteboard> InvitedUsers { get; set; } = new();
    public int MaxConnections { get; set; }
    public WhiteboardAccess AccessStatus { get; set; }
    public WhiteboardType WhiteboardType { get; init; }
    public DateOnly DateCreated { get; init; }
    public int? LifeTime { get; set; }
    public bool IsDeleted { get; set; }
}
