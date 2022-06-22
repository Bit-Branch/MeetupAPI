namespace EventsManagement.Application.Settings
{
    public class JwtSettings
    {
        public const string Position = "JWTSettings";
        public string SecurityKey { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public TimeSpan ExpireIn { get; set; }
    }
}
