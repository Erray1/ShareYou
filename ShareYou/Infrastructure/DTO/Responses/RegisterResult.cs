namespace ShareYou.Infrastructure.DTO.Responses
{
    public class RegisterResult
    {
        public bool Succesful { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}