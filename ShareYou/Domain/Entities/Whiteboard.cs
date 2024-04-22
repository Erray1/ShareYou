using System.ComponentModel.DataAnnotations.Schema;

namespace ShareYou.Domain.Entities;
public sealed class Whiteboard
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string ID { get; set; }
    public byte[] Data { get; set; }
}

