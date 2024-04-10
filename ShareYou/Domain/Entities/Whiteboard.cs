namespace ShareYou.Domain.Entities;

public sealed class Whiteboard
{
    public string ID { get; set; }
    public List<byte[]> Data { get; set; }
}
