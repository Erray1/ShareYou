using ShareYou.Domain.WhiteboardMetadata;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShareYou.Domain.Entities;

public sealed class Whiteboard
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string ID { get; set; }
    public string HostID { get; init; }
    public int MaxConnections { get; set; }
    public WhiteboardAccess AccessStatus { get; set; }
    public WhiteboardType WhiteboardType { get; init; }
    public DateOnly DateCreated { get; init; }
    public int? LifeTime { get; set;}
    
}
