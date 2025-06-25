namespace HaircutSite.Application.Interfaces.Services
{
    public interface IUserJWTService
    {
        Task RegisterUser(string name, string password);
        Task<string> Login(string name, string password);
    }
}
