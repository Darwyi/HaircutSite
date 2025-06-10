using HaircutSite.Application.Interfaces.Services;
using HaircutSite.Domain.Interfaces;
using HaircutSite.Domain.Models;

namespace HaircutSite.Application.Services
{
    public class AppointmentService : IAppointmentService
    {

        private readonly IAppoinmentsRepository _appointmentRepository;
        public AppointmentService(IAppoinmentsRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }
        public async Task<List<Appointment>> GetAllAppointments()
        {
            var appointments = await _appointmentRepository.GetAllAppointments();

            if (appointments is null) throw new Exception("Appointments db don't have any");
            return appointments;
        }

        public async Task<List<Appointment>> GetAppointmentByDate(DateTime time)
        {
            var appointment = await _appointmentRepository.GetAppointmentByDate(time);

            if (appointment is null)
                throw new Exception("No appointments found for the specified date");

            return appointment;
        }

        public async Task CreateAppointment(Appointment appointment)
        {
            if (await GetAppointmentByTime(appointment.Date) != null)
                throw new Exception("Appointment service at current date already in use");

            if (appointment.Date < DateTime.Now)
                throw new Exception("You can't set appointment in the past");

            await _appointmentRepository.CreateAppointment(appointment);
        }


        public async Task<Appointment> GetAppointmentById(Guid id)
        {
            if (await GetAppointmentById(id) is null) throw new Exception("Appointment not found");
            return await _appointmentRepository.GetAppointmentById(id);
        }

        public async Task UpdateAppointment(Appointment appointment)
        {
            if (await GetAppointmentByTime(appointment.Date) != null)
                throw new Exception("You can't set time which already used by another appointment");

            if (GetAppointmentById(appointment.Id) == null)
                throw new Exception("Appointment not found");

            await _appointmentRepository.UpdateAppointment(appointment);
        }

        public async Task DeleteAppointment(Guid id)
        {
            var appointment = await _appointmentRepository.GetAppointmentById(id);
            if (appointment is null)
                throw new Exception("Appointment not found");

            await _appointmentRepository.DeleteAppointment(id);
        }

        public async Task<Appointment> GetAppointmentByTime(DateTime dateTime)
        {
            var appointment = await _appointmentRepository.GetAppointmentByTime(dateTime);

            if (appointment is null)
                throw new Exception("No appointment found for the specified time");

            return appointment;
        }
    }
}
