namespace ShareYou.Infrastructure.DTO.Responses
{
    public class LoginResult
    {
        public bool Succesful { get; set; }
        public string? Error { get; set; } = null;
        public string? Token { get; set; } = null;
    }
}
