using HaircutSite.Domain.Models;

namespace HaircutSite.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
        Task<User> GetUserById(Guid id);
        Task UpdateUser(Guid id, User user);
        Task RegisterUser(User user);
        Task<List<Appointment>?> GetUserAppointments(Guid id);
    }
}
