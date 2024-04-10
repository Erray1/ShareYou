using System.ComponentModel.DataAnnotations.Schema;

namespace ShareYou.Domain.Entities;
public sealed class Message
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string ID { get; set; }
    public string RecieverID { get; set; } = string.Empty;
    public string SenderID { get; set; } = string.Empty;
    public string Title { get; init; }
    public string Description { get; init; }
}

