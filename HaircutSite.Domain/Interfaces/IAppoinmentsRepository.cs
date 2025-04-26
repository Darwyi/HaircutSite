using HaircutSite.Domain.Models;

namespace HaircutSite.Domain.Interfaces
{
    public interface IAppoinmentsRepository
    {
        Task<List<Appointment>> GetAllAppointments();
        Task<List<Appointment>> GetAppointmentByDate(DateTime time);
        Task<Appointment> GetAppointmentById(Guid id);
        Task<Appointment> GetAppointmentByTime(DateTime date);
        Task CreateAppointment(Appointment appointment);
        Task UpdateAppointment(Guid id, Appointment appointment);
        Task DeleteAppointment(Guid id);
    }
}
