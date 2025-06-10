using HaircutSite.Domain.Models;

namespace HaircutSite.Application.Interfaces.Services
{
    public interface IAppointmentService
    {
        Task<List<Appointment>> GetAllAppointments();
        Task<List<Appointment>> GetAppointmentByDate(DateTime time);
        Task<Appointment> GetAppointmentByTime(DateTime dateTime);
        Task<Appointment> GetAppointmentById(Guid id);
        Task CreateAppointment(Appointment appointment);
        Task UpdateAppointment(Appointment appointment);
        Task DeleteAppointment(Guid id);
    }
}
