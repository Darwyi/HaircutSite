using HaircutSite.Domain.Models;

namespace HaircutSite.Application.Interfaces.Auth
{
    public interface IJwtRepository
    {
        string GenerateToken(User user);
    }
}
