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
            return await _dbContext.Appointments.Where(date => date.Date.Date == time).ToListAsync();
        }

        public async Task CreateAppointment(Appointment appointment)
        {
            await _dbContext.Appointments.AddAsync(appointment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Appointment> GetAppointmentById(Guid id)
        {
            return await _dbContext.Appointments.FirstOrDefaultAsync(x => x.Id == id);
        }
        
        public async Task UpdateAppointment(Appointment appointment)
        {
            var existingAppointment = await GetAppointmentById(appointment.Id);

            if (existingAppointment is null)
                throw new Exception("Appointment not found");

            _dbContext.Appointments.Remove(existingAppointment);
            await _dbContext.SaveChangesAsync();

            await _dbContext.Appointments.AddAsync(appointment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAppointment(Guid id)
        {
            _dbContext.Appointments.Remove(await GetAppointmentById(id));
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Appointment> GetAppointmentByTime(DateTime dateTime)
        {
            foreach (var appointment in _dbContext.Appointments)
            {
                var existingServiceIdReturn = await _haircutStyleRepository.GetHaircutStyleById(appointment.haircutStyleId);

                var existingAppointmentEnds = appointment.Date + existingServiceIdReturn.Duration;

                if (dateTime <= existingAppointmentEnds && dateTime >= appointment.Date)
                {
                    return appointment;
                }
            }
            return null;
        }
    }
}
