using HaircutSite.Domain.Models;

namespace HaircutSite.Application.Interfaces
{
    public interface IAppointmentService
    {
        Task<List<Appointment>> GetAllAppointments();
        Task<List<Appointment>> GetAppointmentByDate(DateTime time);
        Task<Appointment> GetAppointmentByTime(DateTime dateTime);
        Task<Appointment> GetAppointmentById(Guid id);
        Task CreateAppointment(Appointment appointment, DateTime time);
        Task UpdateAppointment(Guid id, Appointment appointment);
    }
}
