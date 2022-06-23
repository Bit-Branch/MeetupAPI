namespace MeetupAPI.Application.Options
{
    public class JwtOptions
    {
        public const string Position = "JWTOptions";
        public string SecurityKey { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public TimeSpan ExpireIn { get; set; }
    }
}
