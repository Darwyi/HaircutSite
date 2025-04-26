using HaircutSite.Domain.Models;
using HaircutSite.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HaircutSite.Infrastructure.Repositories
{
    public class UserRepository : HaircutSite.Domain.Interfaces.IUserRepository
    {
        private readonly ApplicationContext _dbContext;

        public UserRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> GetUserById(Guid id)
        {
            var user = await _dbContext.Users.FindAsync(id);

            return user;
        }

        public async Task RegisterUser(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUser(Guid id, User user)
        {
            var trackedEntity = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);

            user.Id = id;
            
            _dbContext.Users.Update(user);
            
            await _dbContext.SaveChangesAsync();
        }
       
 public async Task<List<Appointment>?> GetUserAppointments(Guid id)
        {
            var appointments = await _dbContext.Appointments
                .Where(a => a.UserId == id)
                .ToListAsync();

            return appointments;
        }
    }
}
