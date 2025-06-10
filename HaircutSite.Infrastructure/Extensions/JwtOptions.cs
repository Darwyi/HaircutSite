namespace HaircutSite.Infrastructure.Extensions
{
    public class JwtOptions
    {
        public string SecretKey { get; set; } = string.Empty;
        public int ExpirationHours { get; set; } = 2;
    }
}