using HaircutSite.Application.Interfaces;
using HaircutSite.Domain.Interfaces;
using HaircutSite.Domain.Models;

namespace HaircutSite.Application.Services
{
    public class AppointmentService : IAppointmentService
    {

        private readonly IAppoinmentsRepository _appointmentRepository;
        private readonly IHaircutStyleRepository _haircutstyleRepository;
        public AppointmentService(IAppoinmentsRepository appointmentRepository, IHaircutStyleRepository haircutStyleRepository)
        {
            _appointmentRepository = appointmentRepository;
            _haircutstyleRepository = haircutStyleRepository;
        }
        public async Task<List<Appointment>> GetAllAppointments()
        {
            return await _appointmentRepository.GetAllAppointments();
        }

        public async Task<List<Appointment>> GetAppointmentByDate(DateTime time)
        {
            return await _appointmentRepository.GetAppointmentByDate(time);
        }



        public async Task CreateAppointment(Appointment appointment, DateTime time)
        {
            if (await GetAppointmentByTime(time) != null)
            {
                throw new Exception("Appointment already in use");
            } 
                await _appointmentRepository.CreateAppointment(appointment);
        }


        public async Task<Appointment> GetAppointmentById(Guid id)
        {
            return await _appointmentRepository.GetAppointmentById(id);
        }

        public async Task UpdateAppointment(Guid id, Appointment appointment)
        {
            await _appointmentRepository.UpdateAppointment(id, appointment);
        }

        public async Task<Appointment> GetAppointmentByTime(DateTime dateTime)
        {
            return await _appointmentRepository.GetAppointmentByTime(dateTime);
        }
    }
}
