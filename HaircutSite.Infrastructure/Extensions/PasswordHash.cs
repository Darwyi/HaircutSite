using HaircutSite.Application.Interfaces.Auth;

namespace HaircutSite.Infrastructure.Extensions
{
    public class PasswordHash : IPasswordHashRepository
    {
        public string Generate(string password) =>
            BCrypt.Net.BCrypt.EnhancedHashPassword(password);

        public bool Verify(string password, string hashedPassword) => 
            BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);
    }
}
    