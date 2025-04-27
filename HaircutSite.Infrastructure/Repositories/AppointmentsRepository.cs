using CSharpFunctionalExtensions;
using HaircutSite.Domain.Interfaces;
using HaircutSite.Domain.Models;
using HaircutSite.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HaircutSite.Infrastructure.Repositories 
{
    public class AppointmentsRepository : IAppoinmentsRepository
    {
        private readonly ApplicationContext _dbContext;
        private readonly IHaircutStyleRepository _haircutStyleRepository;
        public AppointmentsRepository(ApplicationContext dbContext, IHaircutStyleRepository haircutStyleRepository)
        {
            _dbContext = dbContext;
            _haircutStyleRepository = haircutStyleRepository;
        }
        public async Task<List<Appointment>> GetAllAppointments()
        {
            return await _dbContext.Appointments.ToListAsync();
        }

        public async Task<List<Appointment>> GetAppointmentByDate(DateTime time)
        {
            //var Date = await _dbContext.Appointments.FirstOrDefaultAsync(date => date.Date == date.Date);

            return await _dbContext.Appointments.Where(date => date.Date.Date == time).ToListAsync();
        }

        public async Task<Appointment> GetAppointmentById(Guid id)
        {

            var appointment = await _dbContext.Appointments.FirstOrDefaultAsync(x => x.Id == id);
            if (appointment is null)
            {
                throw new Exception("Appointment not found");
            }

            return appointment;
        }

        public async Task CreateAppointment(Appointment appointment)
        {
            await _dbContext.Appointments.AddAsync(appointment);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAppointment(Guid id, Appointment appointment)
        {
            var existingAppointment = await _dbContext.Appointments.FindAsync(id);

            if (existingAppointment is null)
            {
                throw new Exception("Appointment not found");
            }

            _dbContext.Appointments.Remove(existingAppointment);
            await _dbContext.SaveChangesAsync();

            appointment.Id = id;

            await _dbContext.Appointments.AddAsync(appointment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAppointment(Guid id)
        {
            var existingAppointment = await _dbContext.Appointments.FindAsync(id);

            if (existingAppointment is null)
            {
                throw new Exception("Appointment not found");
            }

            _dbContext.Appointments.Remove(existingAppointment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Appointment> GetAppointmentByTime(DateTime dateTime)
        {
            //var appointmentDate = await _dbContext.Appointments.FirstOrDefaultAsync(d =>
            //d.Date == dateTime);

            //if (appointmentDate == null) return null;

            //var hSId = appointmentDate.haircutStyleId;

            //var serviceidreturn = await _haircutStyleRepository.GetHaircutStyleById(hSId);

            //var serviceDuration = serviceidreturn.Duration;

            //var appoinmentEnds = appointmentDate.Date + serviceDuration;

            foreach (var appointment in _dbContext.Appointments)
            {
                var existingHSId = appointment.haircutStyleId;

                var existingServiceIdReturn = await _haircutStyleRepository.GetHaircutStyleById(existingHSId);

                var existingServiceDuration = existingServiceIdReturn.Duration;

                var existingAppoinmentEnds = appointment.Date + existingServiceDuration;

                if (dateTime <= existingAppoinmentEnds && dateTime >= appointment.Date)
                {
                    return appointment;
                }
            //if (dateTime >= appointmentDate.Date && appoinmentEnds >= dateTime)
            //{
            //    return appointmentDate;
            //}
            }
            return null;

            //var appointment = await _dbContext.Appointments.FirstOrDefaultAsync(d => d.Date == dateTime);

            //var haircutStyleId = _haircutStyleRepository.GetHaircutStyleById(appointment.haircutStyleId);

            //var haircutStyle = await _dbContext.HairCutStyles
            //    .FirstOrDefaultAsync(h => h.Id == haircutStyleId.Result.Id);

            //var appointmentEnd = appointment.Date + haircutStyle.Duration;

            //if (dateTime >= appointment.Date && dateTime <= appointmentEnd)
            //{
            //    return appointment;
            //}
            //if (appointment == null && haircutStyle == null) return null;

            //return null;


            //return await _dbContext.Appointments.FirstOrDefaultAsync(d =>
            //d.Date.Date == dateTime.Date &&
            //(dateTime.TimeOfDay >= d.Date.TimeOfDay &&
            // dateTime.TimeOfDay <= d.Date.TimeOfDay +
            // _haircutStyleRepository.GetHaircutStyleById(d.haircutStyleId).Result.Duration));
        }
    }
}
