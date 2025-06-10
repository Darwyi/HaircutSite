namespace HaircutSite.Application.Interfaces.Auth
{
    public interface IPasswordHashRepository
    {
        string Generate(string password);
        bool Verify(string password, string hashedPassword);
    }
}
