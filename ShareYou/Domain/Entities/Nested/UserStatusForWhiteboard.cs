
using ShareYou.Domain.WhiteboardData;

namespace ShareYou.Domain.Entities.Nested;
public class UserStatusForWhiteboard
{
    public string UserID { get; set; }
    public WhiteboardAccess AccessLevel { get; set; }
}

